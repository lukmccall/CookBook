import React from 'react';
import { validateEmail } from '../utils';
import { ApiClient, AuthControllerWrapper, TokenToAuth } from '../api';
import { connect } from 'react-redux';
import { userLogged, getUserData } from '../actions/auth';
import ErrorList from './ErrorList';
import { withRouter } from 'react-router-dom';

class RegisterBox extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      username: '',
      email: '',
      password: '',
      errors: [],
      pwdState: null,
    };
  }

  onUsernameChange(e) {
    this.setState({ username: e.target.value });
  }

  onEmailChange(e) {
    this.setState({ email: e.target.value });
  }

  onPasswordChange(e) {
    this.setState({ password: e.target.value });

    let pwdState = 'weak';
    if (e.target.value.length > 8) {
      pwdState = 'medium';
    }
    if (e.target.value.length > 12) {
      pwdState = 'strong';
    }

    this.setState({ pwdState });
  }

  submitRegister = e => {
    e.preventDefault();

    let errors = [];
    if (!validateEmail(this.state.email)) {
      errors.push('Invalid email format.');
    }

    if (this.state.password.length === 0) {
      errors.push('Password can not be empty.');
    }

    if (this.state.username.length === 0) {
      errors.push('Username can not be empty.');
    }

    if (errors.length > 0) {
      this.setState({
        errors,
      });

      return;
    }

    AuthControllerWrapper(
      () =>
        ApiClient.register({
          email: this.state.email,
          password: this.state.password,
          userName: this.state.username,
        }),
      user => {
        this.setState({
          email: '',
          password: '',
          username: '',
          errors: [],
          pwdState: null,
        });

        this.props.userLogged(user);
        this.props.getUserData(TokenToAuth(user.token));
        this.props.history.push('/');

        // TODO: redirect
      },
      errors => this.setState({ errors })
    );
  };

  render() {
    let pwdWeak = false,
      pwdMedium = false,
      pwdStrong = false;

    if (this.state.pwdState === 'weak') {
      pwdWeak = true;
    } else if (this.state.pwdState === 'medium') {
      pwdWeak = true;
      pwdMedium = true;
    } else if (this.state.pwdState === 'strong') {
      pwdWeak = true;
      pwdMedium = true;
      pwdStrong = true;
    }

    return (
      <div className="register-box">
        <div className="register header">Register</div>
        <div className="register box">
          <form onSubmit={this.submitRegister}>
            {this.state.errors.length > 0 && <ErrorList errors={this.state.errors} />}

            <div className="register input-group">
              <label htmlFor="username">Username</label>
              <input
                type="text"
                name="username"
                className="login-input"
                placeholder="Username"
                onChange={this.onUsernameChange.bind(this)}
                value={this.state.username}
              />
            </div>

            <div className="register input-group">
              <label htmlFor="email">Email</label>
              <input
                type="text"
                name="email"
                className="login-input"
                placeholder="Email"
                onChange={this.onEmailChange.bind(this)}
                value={this.state.email}
              />
            </div>

            <div className="register input-group">
              <label htmlFor="password">Password</label>
              <input
                type="password"
                name="password"
                className="login-input"
                placeholder="Password"
                onChange={this.onPasswordChange.bind(this)}
                value={this.state.password}
              />

              {this.state.password && (
                <div className="password-state">
                  <div
                    className={
                      'pwd pwd-weak ' + (pwdWeak ? 'show-login-register-form-panel' : '')
                    }></div>
                  <div
                    className={
                      'pwd pwd-medium ' + (pwdMedium ? 'show-login-register-form-panel' : '')
                    }></div>
                  <div
                    className={
                      'pwd pwd-strong ' + (pwdStrong ? 'show-login-register-form-panel' : '')
                    }></div>
                </div>
              )}
            </div>

            <button type="submit" className="login-btn">
              Register
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

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(RegisterBox));
