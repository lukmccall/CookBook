import React from 'react';

export default class CommentForm extends React.Component {
  render() {
    return (
      <form className="comment-form" onSubmit={this._handleSubmit.bind(this)}>
        <div className="comment-form-fields">
          <textarea
            placeholder="Comment"
            rows="4"
            required
            ref={textarea => (this._body = textarea)}></textarea>
        </div>
        <div className="comment-form-actions">
          <button type="submit">Post Comment</button>
        </div>
      </form>
    );
  }

  _handleSubmit(event) {
    event.preventDefault(); // prevents page from reloading on submit
    let body = this._body;
    this.props.addComment(body.value);
    this._body.value = '';
  }
}
