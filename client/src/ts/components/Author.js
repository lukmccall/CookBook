import React, { Component } from 'react';

import '../../css/author.scss';

export default class Author extends Component {
    render() {
        return (
            <div className="author ">
                <div className="image-cropper">
                    <img src={this.props.photo} alt="avatar" class="profile-pic" />
                </div>
                <br />
                <span className="name">{this.props.name}</span>
                <br />
                <div class="social">
                    <a href={this.props.linkedin}><i class="fab fa-linkedin"></i></a>
                    <a href={this.props.fb}><i class="fab fa-facebook"></i></a>
                    <a href="#"><i class="fab fa-twitter-square"></i></a>
                    <a href="#"><i class="fab fa-instagram"></i></a>
                    <a href="#"><i class="fab fa-spotify"></i></a>
                </div>

            </div>
        )
    }
}





