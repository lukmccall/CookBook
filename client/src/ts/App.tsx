import React, { Component } from 'react';
import { Client } from './Api/Client';
export class App extends Component {
  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col-12 col-lg-3">
            <button
              onClick={async () => {
                const client = new Client('https://localhost:5001');
                console.log(await client.recipeIngredients(1));
              }}>
              dsad
            </button>
          </div>
          <div className="col-12 col-lg-3">dsad</div>
          <div className="col-12 col-lg-3">dasd</div>
          <div className="col-12 col-lg-3">sad</div>
        </div>
      </div>
    );
  }
}
