import React, { Component } from 'react';

import '../../css/contact.scss';
import Author from './Author';

export default class Contact extends Component {
  render() {
    return (
      <div class="wrapper">
        <section class="section parallax bg1">
          <Author
            photo="https://bit.ly/36nPrNK"
            name="ŁUKASZ KOSMATY"
            linkedin="https://bit.ly/2YFoZNc"
            fb="https://bit.ly/2PxtfKn"
          />
          <Author
            photo="https://bit.ly/35bAbDp"
            name="NIKODEM KWAŚNIAK"
            linkedin="https://bit.ly/35amiWe"
            fb="https://bit.ly/38uJ39A"
          />
        </section>
        <section class="strap static">
          <h1>Where to find us?</h1>
        </section>
        <section class="section parallax bg2 flex">
          <div className="map">
            <iframe
              title="googleMaps"
              frameborder="0"
              height="525"
              width="625"
              marginheight="0"
              marginwidth="0"
              scrolling="no"
              src="http://maps.google.com/maps/ms?ie=UTF8&amp;hl=pl&amp;msa=0&amp;msid=112445874310938452608.000481d91fcd4650ee5d1&amp;ll=50.030488,19.910231&amp;spn=0.005858,0.011265&amp;z=16&amp;output=embed"></iframe>
          </div>
        </section>
      </div>
    );
  }
}
