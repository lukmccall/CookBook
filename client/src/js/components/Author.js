import React, { Component } from 'react';

import '../../css/author.scss';

export default class Author extends Component {
  render() {
    return (
      <div className="author">
        <div className="author-image-circle">
          <img src={this.props.photo} alt="avatar" className="author-profile-image" />
        </div>
        <br />
        <span className="author-name">{this.props.name}</span>
        <br />
        <div className="author-social-media-links">
          <a href={this.props.linkedin}>
            <i className="fab fa-linkedin"></i>
          </a>
          <a href={this.props.fb}>
            <i className="fab fa-facebook"></i>
          </a>
          <a href={this.props.git}>
            <i className="fab fa-github"></i>
          </a>
          <a href={this.props.insta}>
            <i className="fab fa-instagram"></i>
          </a>
          <a href={this.props.spotify}>
            <i className="fab fa-spotify"></i>
          </a>
        </div>
      </div>
    );
  }
}
