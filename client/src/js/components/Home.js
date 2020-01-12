import React, { Component } from 'react';
import InputTag from './InputTag';
import RecipeList from './RecipeList';
import RecipeDetails from './RecipeDetails';
import { ApiClient } from '../api';

import ScrollButton from '../components/ScrollButton';

import '../../css/home.scss';
export default class Home extends Component {
  state = {
    tags: [],
    pageIndex: -1,
    recipe: {},
    recipes: [],
  };

  handleSubmit = async tags => {
    this.handleIndex(2);
    ApiClient.searchByIngredients({ ingredients: tags }).then(recipes => {
      this.setState({
        tags: tags,
        pageIndex: 0,
        recipes: recipes,
      });
    });
  };

  handleRecipeDetails = id => {
    this.state.recipes.forEach(element => {
      if (element.id === id) {
        this.setState({
          recipe: element,
          pageIndex: 1,
        });
      }
    });
  };

  handleIndex = pageIndex => {
    this.setState({
      pageIndex: pageIndex,
    });
  };

  loadSteps = async id => {
    return await ApiClient.recipeInstructions(id);
  };

  loadIngridients = async id => {
    return (await ApiClient.recipeVisualization(id, true)).code;
  };

  loadEquipment = async id => {
    return (await ApiClient.equipmentVisualization(id, true)).code;
  };

  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col-12">
            <React.Fragment>
              <InputTag handleSubmit={this.handleSubmit} />

              {this.state.pageIndex === 0 ? (
                <RecipeList
                  recipes={this.state.recipes}
                  handleRecipeDetails={this.handleRecipeDetails}
                />
              ) : (
                ''
              )}

              {this.state.pageIndex === 1 ? (
                <RecipeDetails
                  recipe={this.state.recipe}
                  handleIndex={this.handleIndex}
                  loadSteps={this.loadSteps}
                  loadEquipment={this.loadEquipment}
                  loadIngridients={this.loadIngridients}
                />
              ) : (
                ''
              )}

              {this.state.pageIndex === 2 ? <h2>Loading...</h2> : ''}

              <ScrollButton />
            </React.Fragment>
          </div>
        </div>
      </div>
    );
  }
}
