import React, { Component } from 'react';
import '../../css/about.scss';

export default class About extends Component {
  render() {
    return (
      <div className="about-image-background">
        <div className="about-image-overlay">
          <div className="about-set-top">
            <div className="about-text">
              Project developed for class
              <br />
              <span className="about-bold-text">'WWW Programming'</span>
              <br />
              taken in winter semestr of 2019/2020.
              <br />
              <br />
              It was created by:
              <br />
              <span className="about-bold-text">
                Łukasz Kosmaty
                <br />
                Nikodem Kwaśniak
                </span>
              <br />
              <br />
              Developed using technologies such as:
              <br />
              HTML5, CSS3, React.js and Entity Framework.
              <br />
              <br />
              This project is a single page application, so it won't be reloaded when clicked on any
              button.
            </div>
          </div>
        </div>
      </div>
    );
  }
}
