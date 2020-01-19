import React from 'react';
import Comment from './Comment';
import CommentForm from './CommentForm';
import { ApiClient, TokenToAuth } from '../../api';
import { connect } from 'react-redux';

import '../../../css/comments.scss';

class CommentBox extends React.Component {
  constructor() {
    super();

    this.state = {
      showComments: false,
      comments: [],
    };
  }

  componentDidMount() {
    this.loadComments();
  }

  loadComments = () => {
    this.props.loadComments(this.props.id).then(comments => {
      this.setState({
        comments,
      });
    });
  };

  render() {
    const comments = this._getComments();
    let commentNodes;
    let buttonText = 'Show Comments';

    if (this.state.showComments) {
      buttonText = 'Hide Comments';
      commentNodes = <div className="comment-list">{comments}</div>;
    }

    return (
      <div className="comment-box">
        <h2>Join the Discussion!</h2>
        {this.props.logged ? (
          <CommentForm addComment={this._addComment.bind(this)} />
        ) : (
          <div style={{ marginBottom: 20 }}>You need to be logged to add comments.</div>
        )}

        <button id="comment-reveal" onClick={this._handleClick.bind(this)}>
          {buttonText}
        </button>

        <h3>Comments</h3>
        <h4 className="comment-count">{this._getCommentsTitle(comments.length)}</h4>
        {commentNodes}
      </div>
    );
  }

  _addComment = body => {
    ApiClient.addComment(TokenToAuth(this.props.logged.token), this.props.id, {
      body,
    })
      .then(() => {
        this.loadComments();
      })
      .catch(e => {});
  };

  _handleClick() {
    this.setState({
      showComments: !this.state.showComments,
    });
  }

  _getComments() {
    return this.state.comments.map(comment => {
      return <Comment author={comment.user.userName} body={comment.body} key={comment.id} />;
    });
  }

  _getCommentsTitle(commentCount) {
    if (commentCount === 0) {
      return 'No comments yet';
    } else if (commentCount === 1) {
      return '1 comment';
    } else {
      return `${commentCount} comments`;
    }
  }
}

const mapStateToProps = state => {
  return {
    ...state.auth,
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CommentBox);
