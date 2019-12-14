import React from 'react';
import RegisterBox from './RegisterBox';
import LoginBox from './LoginBox';

import '../../css/login.scss';

export default class SignIn extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoginOpen: true,
      isRegisterOpen: false,
    };
  }

  showLoginBox() {
    this.setState({ isLoginOpen: true, isRegisterOpen: false });
  }

  showRegisterBox() {
    this.setState({ isRegisterOpen: true, isLoginOpen: false });
  }

  render() {
    return (
      <div className="root-container">
        <div className="box-controller">
          <div
            className={'controller ' + (this.state.isLoginOpen ? 'selected-controller' : '')}
            onClick={this.showLoginBox.bind(this)}>
            Login
          </div>
          <div
            className={'controller ' + (this.state.isRegisterOpen ? 'selected-controller' : '')}
            onClick={this.showRegisterBox.bind(this)}>
            Register
          </div>
        </div>

        <div className={this.state.isRegisterOpen ? 'hide' : 'unhide'}>
          <div className="box-container">
            <LoginBox />
          </div>
        </div>
        <div className={this.state.isLoginOpen ? 'hide' : 'unhide'}>
          <div className="box-container">
            <RegisterBox />
          </div>
        </div>
      </div>
    );
  }
}
