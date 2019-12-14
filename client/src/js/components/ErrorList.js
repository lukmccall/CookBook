import React, { Component } from 'react';
import Error from './Error';

import '../../css/errorList.scss';

export default class ErrorList extends Component {
  render() {
    const errorsList = this.props.errors.map(error => <Error key={error} msg={error} />);
    return <ul className="error-list">{errorsList}</ul>;
  }
}
