import React, { Component } from 'react';

import '../../css/contact.scss';
import Author from './Author';

export default class Contact extends Component {
  render() {
    return (
      <div className="contact-wrapper">
        <section className="contact-section contact-parallax bg1">
          <Author
            photo="https://bit.ly/36nPrNK"
            name="ŁUKASZ KOSMATY"
            linkedin="https://bit.ly/2YFoZNc"
            fb="https://bit.ly/2PxtfKn"
            insta="https://instagram.com"
            git="https://github.com/lukmcall"
            spotify="https://spotify.com"
          />
          <Author
            photo="https://bit.ly/35bAbDp"
            name="NIKODEM KWAŚNIAK"
            linkedin="https://bit.ly/35amiWe"
            fb="https://bit.ly/38uJ39A"
            insta="https://instagram.com"
            git="https://github.com/nkwasniak"
            spotify="https://spotify.com"
          />
        </section>
        <section className="contact-bar">
          <h2>Where to find us?</h2>
        </section>
        <section className="contact-section contact-parallax bg2 flex">
          <div className="map">
            <iframe
              title="googleMaps"
              frameBorder="0"
              height="525"
              width="625"
              marginHeight="0"
              marginWidth="0"
              scrolling="no"
              src="http://maps.google.com/maps/ms?ie=UTF8&amp;hl=pl&amp;msa=0&amp;msid=112445874310938452608.000481d91fcd4650ee5d1&amp;ll=50.030488,19.910231&amp;spn=0.005858,0.011265&amp;z=16&amp;output=embed"></iframe>
          </div>
        </section>
      </div>
    );
  }
}
