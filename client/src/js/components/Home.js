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
    pageIndex: 2,
    recipe: {},
    recipes: [],
  };

  handleSubmit = async tags => {
    ApiClient.searchByIngredients({ ingredients: tags }).then(recipes => {
      console.log(recipes);
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

  handleIndex = index => {
    this.setState({
      pageIndex: index,
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
      <React.Fragment>
        <InputTag handleSubmit={this.handleSubmit} />

        {this.state.pageIndex === 0 ? (
          <RecipeList recipes={this.state.recipes} handleRecipeDetails={this.handleRecipeDetails} />
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

        <ScrollButton />
      </React.Fragment>
    );
  }
}
