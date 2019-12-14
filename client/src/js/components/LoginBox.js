import React from 'react';
import { connect } from 'react-redux';
import { userLogged } from '../actions/auth';
import { ApiClient } from '../api';
import ErrorList from './ErrorList';
import { validateEmail } from '../utils';

class LoginBox extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      password: '',
      errors: [],
    };
  }

  handleChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };

  submitLogin = e => {
    e.preventDefault();

    let errors = [];
    if (!validateEmail(this.state.email)) {
      errors.push('Invalid email format.');
    }

    if (this.state.password.length === 0) {
      errors.push('Password can not be empty.');
    }

    if (errors.length > 0) {
      this.setState({
        errors,
      });

      return;
    }

    ApiClient.login({
      email: this.state.email,
      password: this.state.password,
    })
      .then(user => {
        this.setState({
          email: '',
          password: '',
          errors: [],
        });
        this.props.userLogged(user);
        console.log(user);
        // TODO: redirect
      })
      .catch(({ errors }) => {
        this.setState({
          errors: errors,
        });
        console.log(errors);
      });
  };

  render() {
    return (
      <div className="login-box">
        <div className="header">Login</div>
        <div className="box">
          <form onSubmit={this.submitLogin}>
            {this.state.errors.length > 0 && <ErrorList errors={this.state.errors} />}

            <div className="input-group">
              <label htmlFor="email">Email</label>
              <input
                type="email"
                name="email"
                className="login-input"
                placeholder="Email"
                onChange={this.handleChange}
                value={this.state.email}
              />
            </div>

            <div className="input-group">
              <label htmlFor="password">Password</label>
              <input
                type="password"
                name="password"
                className="login-input"
                placeholder="Password"
                onChange={this.handleChange}
                value={this.state.password}
              />
            </div>

            <button type="submit" className="login-btn">
              Login
            </button>
          </form>
        </div>
      </div>
    );
  }
}

const mapStateToProps = state => {
  return {
    user: state.auth,
  };
};

const mapDispatchToProps = { userLogged };

export default connect(mapStateToProps, mapDispatchToProps)(LoginBox);
