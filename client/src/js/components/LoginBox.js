import React from 'react';
import { connect } from 'react-redux';
import { userLogged, getUserData } from '../actions/auth';
import { ApiClient, AuthControllerWrapper, TokenToAuth } from '../api';
import ErrorList from './ErrorList';
import { validateEmail } from '../utils';
import { withRouter } from 'react-router-dom';

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
      errors.push('`Email` must be valid.');
    }

    if (this.state.password.length === 0) {
      errors.push('`Password` must not be empty.');
    }

    if (errors.length > 0) {
      this.setState({
        errors,
      });

      return;
    }

    AuthControllerWrapper(
      () =>
        ApiClient.login({
          email: this.state.email,
          password: this.state.password,
        }),
      user => {
        this.setState({
          email: '',
          password: '',
          errors: [],
        });
        this.props.userLogged(user);
        this.props.getUserData(TokenToAuth(user.token));
        this.props.history.push('/');
      },
      errors => this.setState({ errors })
    );
  };

  render() {
    return (
      <div className="login-box">
        <div className="login header">Login</div>
        <div className="login box">
          <form onSubmit={this.submitLogin}>
            {this.state.errors.length > 0 && <ErrorList errors={this.state.errors} />}

            <div className="login input-group">
              <label htmlFor="email">Email</label>
              <input
                noValidate
                type="email"
                name="email"
                className="login-input"
                placeholder="Email"
                onChange={this.handleChange}
                value={this.state.email}
              />
            </div>

            <div className="login input-group">
              <label htmlFor="password">Password</label>
              <input
                noValidate
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

const mapDispatchToProps = { userLogged, getUserData };

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(LoginBox));
