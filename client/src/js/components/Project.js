import React, { Component } from 'react';
import { markdown } from 'markdown';
import parse from 'html-react-parser';
import '../../css/project.scss';

export default class Project extends Component {
  state = {
    site: <h1>Loading...</h1>,
  };
  async componentDidMount() {
    let requst = await fetch(
      'https://raw.githubusercontent.com/lukmccall/CookBook/master/README.md'
    );
    if (requst.status === 200) {
      let body = await requst.text();

      var site = parse(markdown.toHTML(body));

      this.setState({
        site,
      });
    }
  }
  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col-12 markdown-body">{this.state.site}</div>
        </div>
      </div>
    );
  }
}
