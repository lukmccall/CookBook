import React, { Component } from 'react';

export default class Error extends Component {
  render() {
    return (
      <li>
        <i class="fas fa-exclamation-circle"></i>
        {this.props.msg}
      </li>
    );
  }
}
