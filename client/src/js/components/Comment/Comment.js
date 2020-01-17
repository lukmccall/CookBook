import React from 'react';

export default class Comment extends React.Component {
  render() {
    return (
      <div className="comment">
        <p className="comment-header">{this.props.author}</p>
        <p className="comment-body">- {this.props.body}</p>
        <div className="comment-footer">
          <span href="#" className="comment-footer-delete" onClick={this._deleteComment}>
            Delete Comment
          </span>
        </div>
      </div>
    );
  }
  _deleteComment(e) {
    e.preventDefault();
    alert('-- DELETE Comment Functionality COMMING SOON...');
  }
}
