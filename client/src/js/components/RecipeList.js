import React, { Component } from 'react';
import Recipe from './Recipe';
import '../../css/recipeList.scss';

export default class RecipeList extends Component {
  render() {
    return (
      <div className="recipes-list-head">
        <div className="recipe-list-row">
          <div className="recipes-list-text">
            <h1>Recipes recommended for your ingridients:</h1>
          </div>
        </div>
        <div className="row recipe-list-row">
          {this.props.recipes &&
            this.props.recipes.map(recipe => {
              return (
                <Recipe
                  key={recipe.id}
                  recipe={recipe}
                  title={recipe.title}
                  handleRecipeDetails={this.props.handleRecipeDetails}
                  image_url={recipe.image}
                  id={recipe.id}
                  usedIngredientCount={recipe.usedIngredientCount}
                  missedIngredientCount={recipe.mimissedIngredientCount}
                />
              );
            })}
        </div>
      </div>
    );
  }
}
