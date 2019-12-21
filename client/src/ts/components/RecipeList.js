import React, { Component } from 'react';
import Recipe from './Recipe';
import '../../css/recipeList.scss';

export default class RecipeList extends Component {

    render() {
        return (<div className="container my-5">
            {/* title */}
            <div className="row">
                <div className="text-recipes">
                    <h1 className="text-slanted">Recipes recommended for your ingridients: </h1>
                </div>
            </div>
            {/* end of title */}
            <div className="row">
                {/* <section class="cards"> */}
                {(

                    this.props.recipes.map(recipe => {
                        return (
                            <Recipe
                                key={recipe.id}
                                recipe={recipe}
                                title={recipe.title}
                                handleRecipeDetails={this.props.handleRecipeDetails}
                                image_url={recipe.image}
                                id={recipe.id}
                            />
                        );
                    })
                )}
                {/* </section> */}
            </div>
        </div>)
    }
}