import React from 'react';
import '../../css/inputTag.scss';

export default class InputTag extends React.Component {
  state = {
    tags: []
  };

  onKeyUp = e => {
    if (e.which === 32 || e.which === 13 || e.which === 188) {
      let input = e.target.value.trim().split(/(?:,| )+/).toString();

      if (input.length === 0 || input[0] === '' || input[0] === ',') return; // empty tags

      this.setState({
        tags: [...this.state.tags, input.replace(',', '')],
      });
      e.target.value = '';
    }
  };

  onDeleteTag = tag => {
    var tags = this.state.tags.filter(t => {
      return t !== tag;
    });
    this.setState({
      tags: tags,
    });
  };

  searchClick = () => {
    this.setState({
      tags: [],
    });
  };

  render() {
    return (
      <div className="tags-content">
        <div className="tags-input">
          <input
            type="text"
            onKeyUp={e => this.onKeyUp(e)}
            placeholder="Press enter to add ingridients"
          />
          <button type="submit" onClick={() => {
            if (this.state.tags.length > 0) {
              this.props.handleSubmit(this.state.tags);
              this.searchClick();
            }
          }} value={this.state.tags}>
            <i className="fas fa-search" style={{ pointerEvents: "none" }}></i>
          </button>
        </div>
        <div className="tags-container">
          <ul id="tags">
            {this.state.tags.map((tag, index) => (
              <li key={index} className="tag">
                <span className="tag-title">{tag}</span>
                <span className="tag-close-icon" onClick={() => this.onDeleteTag(tag)}>
                  x
                </span>
              </li>
            ))}
          </ul>
        </div>
      </div>
    );
  }
}
