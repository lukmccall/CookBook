import React, { Component } from 'react';
import InputTag from './InputTag';
import RecipeList from './RecipeList';
import RecipeDetails from './RecipeDetails';
import { recipes } from '../tempList';
import { recipe } from '../tempRecipe';
import { ingrid } from '../tempIngridients';
import { steps } from '../tempSteps';


import ScrollButton from '../components/ScrollButton';


import '../../css/home.scss';
import { throwStatement } from '@babel/types';

export default class Home extends Component {
	state = {
		tags: [],
		pageIndex: 2,
		recipedId: ''
	}


	handleSubmit = (tags) => {
		this.setState({
			tags: tags,
			pageIndex: 0
		});
	}

	handleRecipeDetails = (id) => {
		recipe.ingridients = ingrid.ingredients;
		this.setState({
			recipedId: id,
			pageIndex: 1
		});
	}

	handleIndex = (index) => {
		this.setState({
			pageIndex: index
		})
	}

	loadSteps = () => {
		return steps;
	}

	loadIngridients = () => {
		return `<style type="text/css">
	.spoonacular-switch .slide-button,
	.toggle p span {
		display: none
	}

	@media only screen {
		.toggle {
			position: relative;
			padding: 0;
			margin-left: 100px
		}

		.toggle label {
			position: relative;
			z-index: 3;
			display: block;
			width: 100%
		}

		.toggle input {
			position: absolute;
			opacity: 0;
			z-index: 5
		}

		.toggle p {
			position: absolute;
			left: -100px;
			width: 100%;
			margin: 0;
			padding-right: 100px;
			text-align: left
		}

		.toggle p span {
			position: absolute;
			top: 0;
			left: 0;
			z-index: 5;
			display: block;
			width: 50%;
			margin-left: 100px;
			text-align: center
		}

		.toggle p span:last-child {
			left: 50%
		}

		.toggle .slide-button {
			position: absolute;
			right: 0;
			top: 0;
			z-index: 4;
			display: block;
			width: 50%;
			height: 100%;
			padding: 0
		}

		.spoonacular-switch {
			position: relative;
			padding: 0
		}

		.spoonacular-switch input {
			position: absolute;
			opacity: 0
		}

		.spoonacular-switch label {
			position: relative;
			z-index: 2;
			float: left;
			width: 50%;
			height: 100%;
			margin: 0;
			text-align: center
		}

		.spoonacular-switch .slide-button {
			position: absolute;
			top: 0;
			left: 0;
			padding: 0;
			z-index: 1;
			width: 50%;
			height: 100%
		}

		.spoonacular-switch input:last-of-type:checked~.slide-button {
			left: 50%
		}

		.switch.switch-three label,
		.switch.switch-three .slide-button {
			width: 33.3%
		}

		.switch.switch-three input:checked:nth-of-type(2)~.slide-button {
			left: 33.3%
		}

		.switch.switch-three input:checked:last-of-type~.slide-button {
			left: 66.6%
		}

		.switch.switch-four label,
		.switch.switch-four .slide-button {
			width: 25%
		}

		.switch.switch-four input:checked:nth-of-type(2)~.slide-button {
			left: 25%
		}

		.switch.switch-four input:checked:nth-of-type(3)~.slide-button {
			left: 50%
		}

		.switch.switch-four input:checked:last-of-type~.slide-button {
			left: 75%
		}

		.switch.switch-five label,
		.switch.switch-five .slide-button {
			width: 20%
		}

		.switch.switch-five input:checked:nth-of-type(2)~.slide-button {
			left: 20%
		}

		.switch.switch-five input:checked:nth-of-type(3)~.slide-button {
			left: 40%
		}

		.switch.switch-five input:checked:nth-of-type(4)~.slide-button {
			left: 60%
		}

		.switch.switch-five input:checked:last-of-type~.slide-button {
			left: 80%
		}

		.toggle,
		.spoonacular-switch {
			display: block;
			height: 24px
		}

		.spoonacular-switch *,
		.toggle * {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			-ms-box-sizing: border-box;
			-o-box-sizing: border-box;
			box-sizing: border-box
		}

		.spoonacular-switch .slide-button,
		.toggle .slide-button {
			display: block;
			-webkit-transition: all .3s ease-out;
			-moz-transition: all .3s ease-out;
			-ms-transition: all .3s ease-out;
			-o-transition: all .3s ease-out;
			transition: all .3s ease-out
		}

		.toggle label,
		.toggle p,
		.spoonacular-switch label {
			line-height: 24px;
			vertical-align: middle
		}

		.toggle input:checked~.slide-button {
			right: 50%
		}

		.toggle input:focus~.slide-button,
		.spoonacular-switch input:focus+label {
			outline: 1px dotted #888
		}

		.spoonacular-switch,
		.toggle {
			-webkit-animation: bugfix infinite 1s
		}

		@-webkit-keyframes bugfix {
			from {
				position: relative
			}

			to {
				position: relative
			}
		}

		.spoonacular-metro {
			background-color: #b6b6b6;
			color: #fff
		}

		.spoonacular-metro.toggle {
			border: 2px solid #b6b6b6
		}

		.spoonacular-metro.spoonacular-switch {
			overflow: hidden
		}

		.spoonacular-metro.spoonacular-switch .slide-button {
			background-color: #279fca
		}

		.spoonacular-metro.toggle .slide-button {
			border-radius: 2px;
			background-color: #848484
		}

		.spoonacular-metro.toggle input:first-of-type:checked~.slide-button {
			background-color: #279fca
		}

		.spoonacular-metro p {
			color: #333
		}

		.spoonacular-metro span {
			color: #fff
		}
	}

	.stepper-wrap {
		position: relative;
		display: inline-block;
		font: 11px Arial, sans-serif
	}

	.stepper-wrap input {
		text-align: right
	}

	.stepper-btn-wrap {
		position: absolute;
		top: 0;
		right: -15px;
		width: 15px;
		height: 100%;
		overflow: hidden;
		border: 1px solid #ccc;
		border-left: 0;
		-webkit-border-radius: 0 2px 2px 0;
		-moz-border-radius: 0 2px 2px 0;
		border-radius: 0 2px 2px 0;
		-moz-background-clip: padding;
		-webkit-background-clip: padding-box;
		background-clip: padding-box;
		background-color: #ddd;
		background-image: -webkit-gradient(linear, left top, left bottom, from(#eee), to(#ddd));
		background-image: -webkit-linear-gradient(top, #eee, #ddd);
		background-image: -moz-linear-gradient(top, #eee, #ddd);
		background-image: -ms-linear-gradient(top, #eee, #ddd);
		background-image: -o-linear-gradient(top, #eee, #ddd);
		background-image: linear-gradient(top, #eee, #ddd);
		filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#eee', EndColorStr='#ddd');
		-webkit-box-sizing: border-box;
		-moz-box-sizing: border-box;
		box-sizing: border-box
	}

	.stepper-btn-wrap a {
		display: block;
		height: 50%;
		overflow: hidden;
		line-height: 100%;
		text-align: center;
		text-decoration: none;
		text-shadow: 1px 1px 0 #fff;
		cursor: default;
		color: #666;
		-webkit-box-sizing: border-box;
		-moz-box-sizing: border-box;
		box-sizing: border-box
	}

	.stepper-btn-wrap a:hover {
		background: rgba(255, 255, 255, 0.5)
	}

	#spoonacular-serving-stepper {
		width: 38px;
		height: 26px;
		margin-left: 4px
	}

	.spoonacular-ingredient {
		width: 112px;
		height: 112px;
		position: relative;
		border: 6px solid rgba(30, 30, 30, 0.30);
		margin-right: 10px;
		margin-top: 10px
	}

	.spoonacular-image-wrapper {
		width: 110px;
		height: 105px;
		vertical-align: middle;
		text-align: center;
		line-height: 100px;
		background-color: #fff;
		position: relative
	}

	#spoonacular-ingredient-vis-list .spoonacular-image-wrapper {
		border: 6px solid rgba(30, 30, 30, 0.30);
		width: 80px;
		height: 80px;
		line-height: 80px
	}

	.spoonacular-ingredient img {
		max-width: 100px;
		max-height: 97px;
		vertical-align: middle;
		position: absolute;
		top: 0;
		bottom: 0;
		left: 0;
		right: 0;
		margin: auto
	}

	.spoonacular-ingredient .spoonacular-name,
	.spoonacular-ingredient .spoonacular-amount {
		padding: 0 2px;
		width: 106px;
		height: 0;
		position: absolute;
		background-color: rgba(32, 34, 44, 0.64);
		line-height: 20px;
		color: #fff;
		text-align: center;
		overflow: hidden;
		z-index: 999
	}

	.spoonacular-ingredient div.spoonacular-amount {
		top: 0;
		height: 18px
	}

	.spoonacular-ingredient div.spoonacular-name {
		bottom: 0;
		height: 18px
	}

	.t12 {
		font-size: 12px
	}

	.t11 {
		font-size: 11px
	}

	.t10 {
		font-size: 10px
	}

	.t9 {
		font-size: 9px
	}

	#spoonacular-ingredient-vis-list {
		display: none
	}

	div.spoonacular-ingredient-list {
		border-bottom: 1px solid #036;
		color: #036;
		font-size: 19px;
		line-height: 80px;
		padding: 5px 0
	}

	.spoonacular-ingredient-list img {
		max-width: 80px;
		max-height: 77px;
		vertical-align: middle;
		position: absolute;
		top: 0;
		bottom: 0;
		left: 0;
		right: 0;
		margin: auto
	}

	div.spoonacular-ingredient-list .spoonacular-amount {
		margin-left: 20px;
		width: 90px;
		float: left
	}

	div.spoonacular-ingredient-list .spoonacular-name {
		float: left
	}
</style>
<div class="spoonacular-ingredients-menu">

	<div id="spoonacularView" class="spoonacular-switch spoonacular-metro" style="float:left;width:130px">
		<input id="spoonacular-grid" name="view" type="radio" checked onchange="spoonacularToggleView();">
		<label for="spoonacular-grid" onclick="">grid</label>

		<input id="spoonacular-list" name="view" type="radio" onchange="spoonacularToggleView();">
		<label for="spoonacular-list" onclick="">list</label>

		<span class="slide-button"></span>
	</div>

	<div style="float:left;width:140px;margin-left:20px;line-height:24px">
		<span style="float:left">Servings:</span> <input style="float:left" type="text" size="2" id="spoonacular-serving-stepper" value="6" />
		<span itemprop="recipeYield" id="spoonacular-serving-stepper-initial" style="display:none">6</span>
	</div>

	<div id="spoonacularMeasure" class="spoonacular-switch spoonacular-metro"
		style="float:right;width:130px;margin-right:10px">
		<input id="spoonacular-metric" name="measure" type="radio"  onchange="spoonacularToggleMeasure();">
		<label for="spoonacular-metric" onclick="">metric</label>

		<input id="spoonacular-us" name="measure" type="radio" checked onchange="spoonacularToggleMeasure();">
		<label for="spoonacular-us" onclick="">US</label>

		<span class="slide-button"></span>
	</div>

</div>
<div style="clear:both"></div>
<div id="spoonacular-ingredient-vis-grid">
	<div style="float:left">
		<div class="spoonacular-ingredient">
			<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;" amount="90.0">90 grams</div>
			<div class="spoonacular-amount t12 spoonacular-us" style="display:block;" amount="3.175">3.18 oz</div>
			<div class="spoonacular-image-wrapper">
				<img src="https://spoonacular.com/cdn/ingredients_100x100/plain-protein-powder.png" title="3.18 oz whey protein" alt="3.18 oz whey protein"/></div>
				<div class="spoonacular-name t11">whey protein</div>
			</div>
		</div>
		<div style="float:left">
			<div class="spoonacular-ingredient">
				<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;" amount="150.0">150 grams
				</div>
				<div class="spoonacular-amount t12 spoonacular-us" style="display:block;" amount="5.291">5.29 oz</div>
				<div class="spoonacular-image-wrapper">
					<img src="https://spoonacular.com/cdn/ingredients_100x100/strawberries.png" title="5.29 oz frozen strawberries" alt="5.29 oz frozen strawberries"/></div>
					<div class="spoonacular-name t9">frozen strawberries</div>
				</div>
			</div>
			<div style="float:left">
				<div class="spoonacular-ingredient">
					<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;" amount="150.0">150
						grams</div>
					<div class="spoonacular-amount t12 spoonacular-us" style="display:block;" amount="5.291">5.29 oz
					</div>
					<div class="spoonacular-image-wrapper">
						<img src="https://spoonacular.com/cdn/ingredients_100x100/blueberries.jpg" title="5.29 oz frozen blueberries" alt="5.29 oz frozen blueberries"/></div>
						<div class="spoonacular-name t9">frozen blueberries</div>
					</div>
				</div>
				<div style="float:left">
					<div class="spoonacular-ingredient">
						<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;" amount="3.0">3
						</div>
						<div class="spoonacular-amount t12 spoonacular-us" style="display:block;" amount="3.0">3 </div>
						<div class="spoonacular-image-wrapper">
							<img src="https://spoonacular.com/cdn/ingredients_100x100/bananas.jpg" title="3  bananas" alt="3  bananas"/></div>
							<div class="spoonacular-name t12">bananas</div>
						</div>
					</div>
					<div style="float:left">
						<div class="spoonacular-ingredient">
							<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;" amount="1.0">1
							</div>
							<div class="spoonacular-amount t12 spoonacular-us" style="display:block;" amount="1.0">1
							</div>
							<div class="spoonacular-image-wrapper">
								<img src="https://spoonacular.com/cdn/ingredients_100x100/pomegranate.jpg" title="1  pomegranate" alt="1  pomegranate"/></div>
								<div class="spoonacular-name t11">pomegranate</div>
							</div>
						</div>
						<div style="float:left">
							<div class="spoonacular-ingredient">
								<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;"
									amount="60.0">60 grams</div>
								<div class="spoonacular-amount t12 spoonacular-us" style="display:block;"
									amount="2.116">2.12 oz</div>
								<div class="spoonacular-image-wrapper">
									<img src="https://spoonacular.com/cdn/ingredients_100x100/walnuts.jpg" title="2.12 oz walnuts" alt="2.12 oz walnuts"/></div>
									<div class="spoonacular-name t12">walnuts</div>
								</div>
							</div>
							<div style="float:left">
								<div class="spoonacular-ingredient">
									<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;"
										amount="30.0">30 grams</div>
									<div class="spoonacular-amount t12 spoonacular-us" style="display:block;"
										amount="1.058">1.06 oz</div>
									<div class="spoonacular-image-wrapper">
										<img src="https://spoonacular.com/cdn/ingredients_100x100/pumpkin-seeds.jpg" title="1.06 oz pumpkin seeds" alt="1.06 oz pumpkin seeds"/></div>
										<div class="spoonacular-name t10">pumpkin seeds</div>
									</div>
								</div>
								<div style="float:left">
									<div class="spoonacular-ingredient">
										<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;"
											amount="30.0">30 grams</div>
										<div class="spoonacular-amount t12 spoonacular-us" style="display:block;"
											amount="1.058">1.06 oz</div>
										<div class="spoonacular-image-wrapper">
											<img src="https://spoonacular.com/cdn/ingredients_100x100/flax-seeds.png" title="1.06 oz flaxseed" alt="1.06 oz flaxseed"/></div>
											<div class="spoonacular-name t12">flaxseed</div>
										</div>
									</div>
									<div style="float:left">
										<div class="spoonacular-ingredient">
											<div class="spoonacular-amount t12 spoonacular-metric" style="display:none;"
												amount="180.0">180 grams</div>
											<div class="spoonacular-amount t12 spoonacular-us" style="display:block;"
												amount="6.349">6.35 oz</div>
											<div class="spoonacular-image-wrapper">
												<img src="https://spoonacular.com/cdn/ingredients_100x100/granola.jpg" title="6.35 oz granola" alt="6.35 oz granola"/></div>
												<div class="spoonacular-name t12">granola</div>
											</div>
										</div>
										<div style="float:left">
											<div class="spoonacular-ingredient">
												<div class="spoonacular-amount t12 spoonacular-metric"
													style="display:none;" amount="1.0">1 serving</div>
												<div class="spoonacular-amount t12 spoonacular-us"
													style="display:block;" amount="1.0">1 serving</div>
												<div class="spoonacular-image-wrapper">
													<img src="https://spoonacular.com/cdn/ingredients_100x100/plain-yogurt.jpg" title="ABC Yogurt - 500g" alt="ABC Yogurt - 500g"/></div>
													<div class="spoonacular-name t9">ABC Yogurt - 500g</div>
												</div>
											</div>
											<div style="clear:both"></div>
										</div>
										<div id="spoonacular-ingredient-vis-list">
											<div class="spoonacular-ingredient-list">
												<div style="float:left" itemprop="recipeIngredient"
													content="90 grams whey protein">
													<div class="spoonacular-image-wrapper" style="height:80px">
														<img src="https://spoonacular.com/cdn/ingredients_100x100/plain-protein-powder.png" title="3.18 oz whey protein" alt="3.18 oz whey protein"/></div>
													</div>
													<div class="spoonacular-amount spoonacular-metric"
														style="display:none;width:98px" amount="90.0">90 grams</div>
													<div class="spoonacular-amount spoonacular-us"
														style="display:block;width:98px" amount="3.175">3.18 oz</div>
													<div class="spoonacular-name">whey protein</div>
													<div style="clear:both"></div>
												</div>
												<div class="spoonacular-ingredient-list">
													<div style="float:left" itemprop="recipeIngredient"
														content="150 grams frozen strawberries">
														<div class="spoonacular-image-wrapper" style="height:80px">
															<img src="https://spoonacular.com/cdn/ingredients_100x100/strawberries.png" title="5.29 oz frozen strawberries" alt="5.29 oz frozen strawberries"/></div>
														</div>
														<div class="spoonacular-amount spoonacular-metric"
															style="display:none;width:98px" amount="150.0">150 grams
														</div>
														<div class="spoonacular-amount spoonacular-us"
															style="display:block;width:98px" amount="5.291">5.29 oz
														</div>
														<div class="spoonacular-name">frozen strawberries</div>
														<div style="clear:both"></div>
													</div>
													<div class="spoonacular-ingredient-list">
														<div style="float:left" itemprop="recipeIngredient"
															content="150 grams frozen blueberries">
															<div class="spoonacular-image-wrapper" style="height:80px">
																<img src="https://spoonacular.com/cdn/ingredients_100x100/blueberries.jpg" title="5.29 oz frozen blueberries" alt="5.29 oz frozen blueberries"/></div>
															</div>
															<div class="spoonacular-amount spoonacular-metric"
																style="display:none;width:98px" amount="150.0">150 grams
															</div>
															<div class="spoonacular-amount spoonacular-us"
																style="display:block;width:98px" amount="5.291">5.29 oz
															</div>
															<div class="spoonacular-name">frozen blueberries</div>
															<div style="clear:both"></div>
														</div>
														<div class="spoonacular-ingredient-list">
															<div style="float:left" itemprop="recipeIngredient"
																content="3 bananas">
																<div class="spoonacular-image-wrapper"
																	style="height:80px">
																	<img src="https://spoonacular.com/cdn/ingredients_100x100/bananas.jpg" title="3  bananas" alt="3  bananas"/></div>
																</div>
																<div class="spoonacular-amount spoonacular-metric"
																	style="display:none;width:98px" amount="3.0">3
																</div>
																<div class="spoonacular-amount spoonacular-us"
																	style="display:block;width:98px" amount="3.0">3
																</div>
																<div class="spoonacular-name">bananas</div>
																<div style="clear:both"></div>
															</div>
															<div class="spoonacular-ingredient-list">
																<div style="float:left" itemprop="recipeIngredient"
																	content="1 pomegranate">
																	<div class="spoonacular-image-wrapper"
																		style="height:80px">
																		<img src="https://spoonacular.com/cdn/ingredients_100x100/pomegranate.jpg" title="1  pomegranate" alt="1  pomegranate"/></div>
																	</div>
																	<div class="spoonacular-amount spoonacular-metric"
																		style="display:none;width:98px" amount="1.0">1
																	</div>
																	<div class="spoonacular-amount spoonacular-us"
																		style="display:block;width:98px" amount="1.0">1
																	</div>
																	<div class="spoonacular-name">pomegranate</div>
																	<div style="clear:both"></div>
																</div>
																<div class="spoonacular-ingredient-list">
																	<div style="float:left" itemprop="recipeIngredient"
																		content="60 grams walnuts">
																		<div class="spoonacular-image-wrapper"
																			style="height:80px">
																			<img src="https://spoonacular.com/cdn/ingredients_100x100/walnuts.jpg" title="2.12 oz walnuts" alt="2.12 oz walnuts"/></div>
																		</div>
																		<div class="spoonacular-amount spoonacular-metric"
																			style="display:none;width:98px"
																			amount="60.0">60 grams</div>
																		<div class="spoonacular-amount spoonacular-us"
																			style="display:block;width:98px"
																			amount="2.116">2.12 oz</div>
																		<div class="spoonacular-name">walnuts</div>
																		<div style="clear:both"></div>
																	</div>
																	<div class="spoonacular-ingredient-list">
																		<div style="float:left"
																			itemprop="recipeIngredient"
																			content="30 grams pumpkin seeds">
																			<div class="spoonacular-image-wrapper"
																				style="height:80px">
																				<img src="https://spoonacular.com/cdn/ingredients_100x100/pumpkin-seeds.jpg" title="1.06 oz pumpkin seeds" alt="1.06 oz pumpkin seeds"/></div>
																			</div>
																			<div class="spoonacular-amount spoonacular-metric"
																				style="display:none;width:98px"
																				amount="30.0">30 grams</div>
																			<div class="spoonacular-amount spoonacular-us"
																				style="display:block;width:98px"
																				amount="1.058">1.06 oz</div>
																			<div class="spoonacular-name">pumpkin seeds
																			</div>
																			<div style="clear:both"></div>
																		</div>
																		<div class="spoonacular-ingredient-list">
																			<div style="float:left"
																				itemprop="recipeIngredient"
																				content="30 grams flaxseed">
																				<div class="spoonacular-image-wrapper"
																					style="height:80px">
																					<img src="https://spoonacular.com/cdn/ingredients_100x100/flax-seeds.png" title="1.06 oz flaxseed" alt="1.06 oz flaxseed"/></div>
																				</div>
																				<div class="spoonacular-amount spoonacular-metric"
																					style="display:none;width:98px"
																					amount="30.0">30 grams</div>
																				<div class="spoonacular-amount spoonacular-us"
																					style="display:block;width:98px"
																					amount="1.058">1.06 oz</div>
																				<div class="spoonacular-name">flaxseed
																				</div>
																				<div style="clear:both"></div>
																			</div>
																			<div class="spoonacular-ingredient-list">
																				<div style="float:left"
																					itemprop="recipeIngredient"
																					content="180 grams granola">
																					<div class="spoonacular-image-wrapper"
																						style="height:80px">
																						<img src="https://spoonacular.com/cdn/ingredients_100x100/granola.jpg" title="6.35 oz granola" alt="6.35 oz granola"/></div>
																					</div>
																					<div class="spoonacular-amount spoonacular-metric"
																						style="display:none;width:98px"
																						amount="180.0">180 grams</div>
																					<div class="spoonacular-amount spoonacular-us"
																						style="display:block;width:98px"
																						amount="6.349">6.35 oz</div>
																					<div class="spoonacular-name">
																						granola</div>
																					<div style="clear:both"></div>
																				</div>
																				<div itemprop="ingredients"
																					class="spoonacular-ingredient-list">
																					<div style="float:left">
																						<div class="spoonacular-image-wrapper"
																							style="height:80px">
																							<img src="https://spoonacular.com/cdn/ingredients_100x100/plain-yogurt.jpg" title="1 serving ABC Yogurt - 500g" alt="1 serving ABC Yogurt - 500g"/></div>
																						</div>
																						<div class="spoonacular-amount spoonacular-metric"
																							style="display:none;width:98px"
																							amount="1.0">1 serving</div>
																						<div class="spoonacular-amount spoonacular-us"
																							style="display:block;width:98px"
																							amount="1.0">1 serving</div>
																						<div class="spoonacular-name">
																							ABC Yogurt - 500g</div>
																						<div style="clear:both"></div>
																					</div>
																				</div>
																				<div
																					style="margin-top:3px;margin-right:10px;text-align:right;">
																					Widget by <a
																						href="https://spoonacular.com">spoonacular.com</a>
																				</div>`
	}

	loadEquipment = () => {
		return `<style type="text/css">
	.spoonacular-switch .slide-button,
	.toggle p span {
		display: none
	}

	@media only screen {
		.toggle {
			position: relative;
			padding: 0;
			margin-left: 100px
		}

		.toggle label {
			position: relative;
			z-index: 3;
			display: block;
			width: 100%
		}

		.toggle input {
			position: absolute;
			opacity: 0;
			z-index: 5
		}

		.toggle p {
			position: absolute;
			left: -100px;
			width: 100%;
			margin: 0;
			padding-right: 100px;
			text-align: left
		}

		.toggle p span {
			position: absolute;
			top: 0;
			left: 0;
			z-index: 5;
			display: block;
			width: 50%;
			margin-left: 100px;
			text-align: center
		}

		.toggle p span:last-child {
			left: 50%
		}

		.toggle .slide-button {
			position: absolute;
			right: 0;
			top: 0;
			z-index: 4;
			display: block;
			width: 50%;
			height: 100%;
			padding: 0
		}

		.spoonacular-switch {
			position: relative;
			padding: 0
		}

		.spoonacular-switch input {
			position: absolute;
			opacity: 0
		}

		.spoonacular-switch label {
			position: relative;
			z-index: 2;
			float: left;
			width: 50%;
			height: 100%;
			margin: 0;
			text-align: center
		}

		.spoonacular-switch .slide-button {
			position: absolute;
			top: 0;
			left: 0;
			padding: 0;
			z-index: 1;
			width: 50%;
			height: 100%
		}

		.spoonacular-switch input:last-of-type:checked~.slide-button {
			left: 50%
		}

		.switch.switch-three label,
		.switch.switch-three .slide-button {
			width: 33.3%
		}

		.switch.switch-three input:checked:nth-of-type(2)~.slide-button {
			left: 33.3%
		}

		.switch.switch-three input:checked:last-of-type~.slide-button {
			left: 66.6%
		}

		.switch.switch-four label,
		.switch.switch-four .slide-button {
			width: 25%
		}

		.switch.switch-four input:checked:nth-of-type(2)~.slide-button {
			left: 25%
		}

		.switch.switch-four input:checked:nth-of-type(3)~.slide-button {
			left: 50%
		}

		.switch.switch-four input:checked:last-of-type~.slide-button {
			left: 75%
		}

		.switch.switch-five label,
		.switch.switch-five .slide-button {
			width: 20%
		}

		.switch.switch-five input:checked:nth-of-type(2)~.slide-button {
			left: 20%
		}

		.switch.switch-five input:checked:nth-of-type(3)~.slide-button {
			left: 40%
		}

		.switch.switch-five input:checked:nth-of-type(4)~.slide-button {
			left: 60%
		}

		.switch.switch-five input:checked:last-of-type~.slide-button {
			left: 80%
		}

		.toggle,
		.spoonacular-switch {
			display: block;
			height: 24px
		}

		.spoonacular-switch *,
		.toggle * {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			-ms-box-sizing: border-box;
			-o-box-sizing: border-box;
			box-sizing: border-box
		}

		.spoonacular-switch .slide-button,
		.toggle .slide-button {
			display: block;
			-webkit-transition: all .3s ease-out;
			-moz-transition: all .3s ease-out;
			-ms-transition: all .3s ease-out;
			-o-transition: all .3s ease-out;
			transition: all .3s ease-out
		}

		.toggle label,
		.toggle p,
		.spoonacular-switch label {
			line-height: 24px;
			vertical-align: middle
		}

		.toggle input:checked~.slide-button {
			right: 50%
		}

		.toggle input:focus~.slide-button,
		.spoonacular-switch input:focus+label {
			outline: 1px dotted #888
		}

		.spoonacular-switch,
		.toggle {
			-webkit-animation: bugfix infinite 1s
		}

		@-webkit-keyframes bugfix {
			from {
				position: relative
			}

			to {
				position: relative
			}
		}

		.spoonacular-metro {
			background-color: #b6b6b6;
			color: #fff
		}

		.spoonacular-metro.toggle {
			border: 2px solid #b6b6b6
		}

		.spoonacular-metro.spoonacular-switch {
			overflow: hidden
		}

		.spoonacular-metro.spoonacular-switch .slide-button {
			background-color: #279fca
		}

		.spoonacular-metro.toggle .slide-button {
			border-radius: 2px;
			background-color: #848484
		}

		.spoonacular-metro.toggle input:first-of-type:checked~.slide-button {
			background-color: #279fca
		}

		.spoonacular-metro p {
			color: #333
		}

		.spoonacular-metro span {
			color: #fff
		}
	}

	.stepper-wrap {
		position: relative;
		display: inline-block;
		font: 11px Arial, sans-serif
	}

	.stepper-wrap input {
		text-align: right
	}

	.stepper-btn-wrap {
		position: absolute;
		top: 0;
		right: -15px;
		width: 15px;
		height: 100%;
		overflow: hidden;
		border: 1px solid #ccc;
		border-left: 0;
		-webkit-border-radius: 0 2px 2px 0;
		-moz-border-radius: 0 2px 2px 0;
		border-radius: 0 2px 2px 0;
		-moz-background-clip: padding;
		-webkit-background-clip: padding-box;
		background-clip: padding-box;
		background-color: #ddd;
		background-image: -webkit-gradient(linear, left top, left bottom, from(#eee), to(#ddd));
		background-image: -webkit-linear-gradient(top, #eee, #ddd);
		background-image: -moz-linear-gradient(top, #eee, #ddd);
		background-image: -ms-linear-gradient(top, #eee, #ddd);
		background-image: -o-linear-gradient(top, #eee, #ddd);
		background-image: linear-gradient(top, #eee, #ddd);
		filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#eee', EndColorStr='#ddd');
		-webkit-box-sizing: border-box;
		-moz-box-sizing: border-box;
		box-sizing: border-box
	}

	.stepper-btn-wrap a {
		display: block;
		height: 50%;
		overflow: hidden;
		line-height: 100%;
		text-align: center;
		text-decoration: none;
		text-shadow: 1px 1px 0 #fff;
		cursor: default;
		color: #666;
		-webkit-box-sizing: border-box;
		-moz-box-sizing: border-box;
		box-sizing: border-box
	}

	.stepper-btn-wrap a:hover {
		background: rgba(255, 255, 255, 0.5)
	}

	#spoonacular-serving-stepper {
		width: 38px;
		height: 26px;
		margin-left: 4px
	}

	.spoonacular-equipment {
		width: 112px;
		height: 112px;
		position: relative;
		border: 6px solid rgba(30, 30, 30, 0.30);
		margin-right: 10px;
		margin-top: 10px
	}

	.spoonacular-image-wrapper {
		width: 110px;
		height: 105px;
		vertical-align: middle;
		text-align: center;
		line-height: 100px;
		background-color: #fff;
		position: relative
	}

	#spoonacular-equipment-vis-list .spoonacular-image-wrapper {
		border: 6px solid rgba(30, 30, 30, 0.30);
		width: 80px;
		height: 80px;
		line-height: 80px
	}

	.spoonacular-equipment img {
		max-width: 100px;
		max-height: 97px;
		vertical-align: middle;
		position: absolute;
		top: 0;
		bottom: 0;
		left: 0;
		right: 0;
		margin: auto
	}

	.spoonacular-equipment .spoonacular-name,
	.spoonacular-equipment .spoonacular-amount {
		padding: 0 2px;
		width: 106px;
		height: 0;
		position: absolute;
		background-color: rgba(32, 34, 44, 0.64);
		line-height: 20px;
		color: #fff;
		text-align: center;
		overflow: hidden;
		z-index: 999
	}

	.spoonacular-equipment div.spoonacular-name {
		bottom: 0;
		height: 18px
	}

	.t12 {
		font-size: 12px
	}

	.t11 {
		font-size: 11px
	}

	.t10 {
		font-size: 10px
	}

	.t9 {
		font-size: 9px
	}

	#spoonacular-equipment-vis-list {
		display: none
	}

	div.spoonacular-equipment-list {
		border-bottom: 1px solid #036;
		color: #036;
		font-size: 19px;
		line-height: 80px;
		padding: 5px 0
	}

	.spoonacular-equipment-list img {
		max-width: 80px;
		max-height: 77px;
		vertical-align: middle;
		position: absolute;
		top: 0;
		bottom: 0;
		left: 0;
		right: 0;
		margin: auto
	}

	div.spoonacular-equipment-list .spoonacular-name {
		float: left
	}
</style>
<div class="spoonacular-ingredients-menu">

	<div id="spoonacularEquipmentView" class="spoonacular-switch spoonacular-metro" style="float:left;width:130px">
		<input id="spoonacular-equipment-grid" name="view" type="radio" checked onchange="spoonacularToggleEquipmentView();">
		<label for="spoonacular-equipment-grid" onclick="">grid</label>

		<input id="spoonacular-equipment-list" name="view" type="radio" onchange="spoonacularToggleEquipmentView();">
		<label for="spoonacular-equipment-list" onclick="">list</label>

		<span class="slide-button"></span>
	</div>

</div>
<div style="clear:both"></div>
<div id="spoonacular-equipment-vis-grid">
	<div style="float:left">
		<div class="spoonacular-equipment">
			<div class="spoonacular-image-wrapper">
				<img src="https://spoonacular.com/cdn/equipment_100x100/hand-mixer.png" title="hand mixer" alt="hand mixer"/></div>
				<div class="spoonacular-name t12">hand mixer</div>
			</div>
		</div>
		<div style="float:left">
			<div class="spoonacular-equipment">
				<div class="spoonacular-image-wrapper">
					<img src="https://spoonacular.com/cdn/equipment_100x100/potato-masher.jpg" title="potato masher" alt="potato masher"/></div>
					<div class="spoonacular-name t10">potato masher</div>
				</div>
			</div>
			<div style="float:left">
				<div class="spoonacular-equipment">
					<div class="spoonacular-image-wrapper">
						<img src="https://spoonacular.com/cdn/equipment_100x100/roasting-pan.jpg" title="baking pan" alt="baking pan"/></div>
						<div class="spoonacular-name t12">baking pan</div>
					</div>
				</div>
				<div style="float:left">
					<div class="spoonacular-equipment">
						<div class="spoonacular-image-wrapper">
							<img src="https://spoonacular.com/cdn/equipment_100x100/mixing-bowl.jpg" title="mixing bowl" alt="mixing bowl"/></div>
							<div class="spoonacular-name t11">mixing bowl</div>
						</div>
					</div>
					<div style="float:left">
						<div class="spoonacular-equipment">
							<div class="spoonacular-image-wrapper">
								<img src="https://spoonacular.com/cdn/equipment_100x100/dutch-oven.jpg" title="dutch oven" alt="dutch oven"/></div>
								<div class="spoonacular-name t12">dutch oven</div>
							</div>
						</div>
						<div style="float:left">
							<div class="spoonacular-equipment">
								<div class="spoonacular-image-wrapper">
									<img src="https://spoonacular.com/cdn/equipment_100x100/microwave.jpg" title="microwave" alt="microwave"/></div>
									<div class="spoonacular-name t12">microwave</div>
								</div>
							</div>
							<div style="float:left">
								<div class="spoonacular-equipment">
									<div class="spoonacular-image-wrapper">
										<img src="https://spoonacular.com/cdn/equipment_100x100/blender.png" title="blender" alt="blender"/></div>
										<div class="spoonacular-name t12">blender</div>
									</div>
								</div>
								<div style="clear:both"></div>
							</div>
							<div id="spoonacular-equipment-vis-list">
								<div class="spoonacular-equipment-list">
									<div style="float:left">
										<div class="spoonacular-image-wrapper" style="height:80px">
											<img src="https://spoonacular.com/cdn/equipment_100x100/hand-mixer.png" title="hand mixer" alt="hand mixer"/></div>
										</div>
										<div class="spoonacular-name">hand mixer</div>
										<div style="clear:both"></div>
									</div>
									<div class="spoonacular-equipment-list">
										<div style="float:left">
											<div class="spoonacular-image-wrapper" style="height:80px">
												<img src="https://spoonacular.com/cdn/equipment_100x100/potato-masher.jpg" title="potato masher" alt="potato masher"/></div>
											</div>
											<div class="spoonacular-name">potato masher</div>
											<div style="clear:both"></div>
										</div>
										<div class="spoonacular-equipment-list">
											<div style="float:left">
												<div class="spoonacular-image-wrapper" style="height:80px">
													<img src="https://spoonacular.com/cdn/equipment_100x100/roasting-pan.jpg" title="baking pan" alt="baking pan"/></div>
												</div>
												<div class="spoonacular-name">baking pan</div>
												<div style="clear:both"></div>
											</div>
											<div class="spoonacular-equipment-list">
												<div style="float:left">
													<div class="spoonacular-image-wrapper" style="height:80px">
														<img src="https://spoonacular.com/cdn/equipment_100x100/mixing-bowl.jpg" title="mixing bowl" alt="mixing bowl"/></div>
													</div>
													<div class="spoonacular-name">mixing bowl</div>
													<div style="clear:both"></div>
												</div>
												<div class="spoonacular-equipment-list">
													<div style="float:left">
														<div class="spoonacular-image-wrapper" style="height:80px">
															<img src="https://spoonacular.com/cdn/equipment_100x100/dutch-oven.jpg" title="dutch oven" alt="dutch oven"/></div>
														</div>
														<div class="spoonacular-name">dutch oven</div>
														<div style="clear:both"></div>
													</div>
													<div class="spoonacular-equipment-list">
														<div style="float:left">
															<div class="spoonacular-image-wrapper" style="height:80px">
																<img src="https://spoonacular.com/cdn/equipment_100x100/microwave.jpg" title="microwave" alt="microwave"/></div>
															</div>
															<div class="spoonacular-name">microwave</div>
															<div style="clear:both"></div>
														</div>
														<div class="spoonacular-equipment-list">
															<div style="float:left">
																<div class="spoonacular-image-wrapper"
																	style="height:80px">
																	<img src="https://spoonacular.com/cdn/equipment_100x100/blender.png" title="blender" alt="blender"/></div>
																</div>
																<div class="spoonacular-name">blender</div>
																<div style="clear:both"></div>
															</div>
														</div>
														<div style="margin-top:3px;margin-right:10px;text-align:right;">
															Widget by <a
																href="https://spoonacular.com">spoonacular.com</a></div>`
	}

	render() {
		return (
			<React.Fragment>
				<InputTag handleSubmit={this.handleSubmit} />

				{this.state.pageIndex === 0 ? <RecipeList recipes={recipes}
					handleRecipeDetails={this.handleRecipeDetails} /> : ""}

				{this.state.pageIndex === 1 ? <RecipeDetails recipe={recipe}
					handleIndex={this.handleIndex}
					loadSteps={this.loadSteps}
					loadEquipment={this.loadEquipment}
					loadIngridients={this.loadIngridients} /> : ""}

				<ScrollButton />
			</React.Fragment>
		);
	}
}
