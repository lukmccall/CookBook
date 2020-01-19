import React, { Component } from 'react';
import { connect } from 'react-redux';
import { ApiClient, TokenToAuth, GetStaticUrl } from '../api';
import { getUserData, logout } from '../actions/auth';
import { Redirect } from 'react-router-dom';
import ErrorList from './ErrorList';
import { withRouter } from 'react-router-dom';
import '../../css/profile.scss';

class Profile extends Component {
  state = {
    userName: '',
    userSurname: '',
    age: 0,
    description: '',
    phoneNumber: '',
    errors: [],
    photoUrl: '',
  };

  photoInput = React.createRef();

  componentDidMount() {
    this.updateUserData();
  }

  updateUserData = () => {
    if (this.props.user) {
      this.setState({
        userName: this.props.user.userName || this.state.userName,
        userSurname: this.props.user.userSurname || this.state.userSurname,
        age: this.props.user.age || this.state.age,
        description: this.props.user.description || this.state.description,
        phoneNumber: this.props.user.phoneNumber || this.state.phoneNumber,
        photoUrl: this.props.user.photoUrl || this.state.photoUrl,
      });
    }
  };

  logout = () => {
    this.props.logout(this.props.logged.token);
    this.props.history.push('/');
  };

  loading = () => {
    return (
      <div className="container">
        <h2>Loading...</h2>
      </div>
    );
  };

  handleChange = event => {
    this.setState({ [event.target.name]: event.target.value });
  };

  notEmptyOrNull = s => {
    if (s === null || s === undefined) {
      return false;
    }

    if (s === '') {
      return false;
    }

    return true;
  };

  onSubmit = event => {
    event.preventDefault();
    let request = {};

    for (const [key, value] of Object.entries(this.state)) {
      if (key === 'age') {
        request[key] = parseInt(value);
      } else if (this.notEmptyOrNull(value)) {
        request[key] = value;
      }
    }
    if (this.state.userName) {
      ApiClient.updateCurrentUser(TokenToAuth(this.props.logged.token), request)
        .then(data => {
          this.props.getUserData(TokenToAuth(this.props.logged.token));
          this.setState({
            errors: [],
            needToBeUpdated: true,
          });
        })
        .catch(() => {
          this.setState({
            errors: ['Invalide data'],
          });
        });
    }
  };

  uploadPhoto = event => {
    event.preventDefault();
    const photoList = this.photoInput?.current?.files;
    if (!photoList && photoList.length > 0) {
      this.setState({
        errors: ['Photo is required'],
      });
      return;
    }

    let formData = new FormData();

    formData.append('picture', photoList[0]);
    fetch(`${ApiClient.baseUrl}/api/v1/user/changePicture`, {
      method: 'POST',
      body: formData,
      headers: {
        Authorization: TokenToAuth(this.props.logged.token),
      },
    })
      .then(async data => {
        this.setState({
          errors: [],
        });
        this.props.getUserData(TokenToAuth(this.props.logged.token));
        const photoUrl = await data.text();
        this.setState({
          photoUrl: photoUrl.replace(/"/g, ''),
        });
      })
      .catch(() => {
        this.setState({
          errors: ['Invalide photo'],
        });
      });
  };

  main = () => {
    return (
      <div className="container profile-container">
        <div className="row profile-header align-center">
          <div className="col-6 col-offset-2">Logged as {this.props.user.userName}</div>
          <div className="col-2">
            <button onClick={this.logout} className="profile-button">
              Logout
            </button>
          </div>
        </div>

        <div className="row profile-form-row">
          <div className="col-sm-3 col-12">
            <img
              className="profile-image"
              src={GetStaticUrl(
                this.state.photoUrl !== '' ? this.state.photoUrl : '/static/defaultAvatar.jpg'
              )}
              alt="avatar"
            />
            <form encType="multipart/form-data" onSubmit={this.uploadPhoto}>
              <input
                type="file"
                id="avatar"
                name="avatar"
                accept="image/png, image/jpeg"
                ref={this.photoInput}
              />
              <button className="profile-button" type="submit">
                Save photo
              </button>
            </form>
          </div>
          <div className="col-sm-9 col-12">
            <form onSubmit={this.onSubmit}>
              {this.state.errors.length > 0 && <ErrorList errors={this.state.errors} />}

              <div className="profile-group">
                <label htmlFor="userName">Username:</label>
                <input
                  type="text"
                  name="userName"
                  id="userName"
                  onChange={this.handleChange}
                  value={this.state.userName}
                />
              </div>
              <div className="profile-group">
                <label htmlFor="userSurname">Surname:</label>
                <input
                  type="text"
                  name="userSurname"
                  id="userSurname"
                  onChange={this.handleChange}
                  value={this.state.userSurname}
                />
              </div>
              <div className="profile-group">
                <label htmlFor="age">Age:</label>
                <input
                  type="number"
                  name="age"
                  id="age"
                  onChange={this.handleChange}
                  value={this.state.age}
                />
              </div>
              <div className="profile-group">
                <label htmlFor="description">Description:</label>
                <input
                  type="text"
                  name="description"
                  id="description"
                  onChange={this.handleChange}
                  value={this.state.description}
                />
              </div>
              <div className="profile-group">
                <label htmlFor="phoneNumber">Phone number:</label>
                <input
                  type="tel"
                  name="phoneNumber"
                  id="phoneNumber"
                  onChange={this.handleChange}
                  value={this.state.phoneNumber}
                />
              </div>

              <button className="profile-button" type="submit">
                Save
              </button>
            </form>
          </div>
        </div>
      </div>
    );
  };

  render() {
    if (this.props.user) {
      return this.main();
    } else if (this.props.logged) {
      this.props.getUserData(TokenToAuth(this.props.logged.token));
      return this.loading();
    } else {
      return <Redirect to="/"></Redirect>;
    }
  }
}

const mapStateToProps = state => {
  return {
    ...state.auth,
  };
};

const mapDispatchToProps = { getUserData, logout };

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Profile));
