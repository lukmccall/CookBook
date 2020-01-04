import React, { Component } from "react";
import '../../css/recipe.scss';

export default class Recipe extends Component {
    render() {
        const {
            image,
            title,
            id,
            usedIngredientCount,
            missedIngredientCount,
        } = this.props.recipe;
        return (
            <React.Fragment>
                <article className="recipe-card">
                    <div className="recipe-card-info-hover">
                        <div className="recipe-card-used-ingredients">
                            <i className="fas fa-check-circle"></i>
                            <span className="recipe-card-info-ingredients">Used ingredients: {usedIngredientCount}</span>
                        </div>
                        <div className="recipe-card-missed-ingredients">
                            <i className="fas fa-times-circle"></i>
                            <span className="recipe-card-info-ingredients">Missed ingredients: {missedIngredientCount}</span>
                        </div>
                    </div>
                    <div className="recipe-card-img" style={{ backgroundImage: `url(${image})` }} ></div>
                    <div className="recipe-card-link">
                        <div className="recipe-card-img-hover"
                            onClick={() => this.props.handleRecipeDetails(id)}
                            style={{ backgroundImage: `url(${image})` }}>
                        </div>
                    </div>
                    <div className="recipe-card-info">
                        <h3 className="recipe-card-title">{title}</h3>
                    </div>
                </article>
            </React.Fragment >
        );
    }
}