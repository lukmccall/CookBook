import React, { Component } from 'react';
import Accordion from './Accordion';
import CommentBox from './Comment/CommentBox';

import '../../css/recipeDetails.scss';

export default class RecipeDetails extends Component {
  state = {
    stepsArray: [],
  };
  componentDidMount() {}

  onClickIngridients = async () => {
    document.getElementById('ingridients').innerHTML = await this.props.loadIngridients(
      this.props.recipe.id
    );
  };

  onClickEquipment = async () => {
    document.getElementById('equipment').innerHTML = await this.props.loadEquipment(
      this.props.recipe.id
    );
  };

  onClickSteps = async () => {
    this.setState({
      stepsArray: await this.props.loadSteps(this.props.recipe.id),
    });
  };

  render() {
    const { image, title } = this.props.recipe;

    return (
      <React.Fragment>
        <div className="recipe-details">
          <div className="recipe-details-row">
            <button
              type="button"
              className="btn-back-to-recipe-list"
              onClick={() => this.props.handleIndex(0)}>
              <span>back to recipe list</span>
            </button>
            <div className="recipe-details-left-side side">
              <div className="recipe-details-image-block">
                <img src={image} alt="recipe" width="80%" />
                <div className="recipe-details-title">{title}</div>
                <CommentBox />
              </div>
            </div>
            <div className="recipe-details-right-side side">
              <Accordion>
                <div className="accor">
                  <div className="accor-title" onClick={this.onClickIngridients}>
                    {' '}
                    Ingredients
                  </div>
                  <div className="accor-details" id="ingridients"></div>
                </div>
                <div className="accor">
                  <div className="accor-title" onClick={this.onClickEquipment}>
                    {' '}
                    Equipment
                  </div>
                  <div className="accor-details" id="equipment"></div>
                </div>
                <div className="accor">
                  <div className="accor-title" onClick={this.onClickSteps}>
                    {' '}
                    Steps
                  </div>
                  <div className="accor-details" id="steps">
                    {this.state.stepsArray.length > 0
                      ? this.state.stepsArray.map((s, index) => {
                          return (
                            <div key={index} className="steps">
                              <div className="steps-title">{s.name} </div>
                              <div className="instruction">
                                {s.steps.map((x, i) => {
                                  return (
                                    <p key={i}>
                                      {x.number}. {x.step}
                                    </p>
                                  );
                                })}
                              </div>
                            </div>
                          );
                        })
                      : ''}
                  </div>
                </div>
              </Accordion>
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  }
}
