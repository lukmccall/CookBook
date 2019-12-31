import React, { Component } from "react";
import Accordion from './Accordion';
import CommentBox from './Comment/CommentBox';

import '../../css/recipeDetails.scss';

export default class RecipeDetails extends Component {
	state = {
		stepsArray: []
	}
	componentDidMount() {
		console.log("did monut");
		// const iframe = this.refs.iframe;
		// const document = iframe.contentDocument;
		// const head = document.getElementsByTagName('head')[0];

	}

	onClickIngridients = () => {
		document.getElementById('ingridients').innerHTML = this.props.loadIngridients();
	}

	onClickEquipment = () => {
		document.getElementById('equipment').innerHTML = this.props.loadEquipment();
	}

	onClickSteps = () => {
		this.setState({
			stepsArray: this.props.loadSteps()
		})

		// document.getElementById('equipment').innerHTML=<div>TWOJA STARA</div>;
	}

	render() {
		const {
			image,
			publisher,
			publisher_url,
			source_url,
			title,
			ingridients,
			id
		} = this.props.recipe;
		const { handleIndex } = this.props;
		// if (!ingredients) {
		//     return <h1>loading ....</h1>;
		// }
		// if (ingridients) {
		console.log(ingridients);
		return (
			<React.Fragment>
				<div className="container">
					<div className="row">
						<button
							type="button"
							className="button-back"
							onClick={() => this.props.handleIndex(0)}
						>
							<span>back to recipe list</span>
						</button>
						<div className="left-side side">
							<div className="block">
								<img src={image} className="d-block w-100" alt="recipe" width="80%" />
								<div className="recipe-title">{title}</div>
								<CommentBox />
							</div>
						</div>
						<div className="right-side side">
							<Accordion>
								{/* <div className="accor">
                                <div className="head">Ingredients</div>
                                <div className="body">
                                    <table>
                                        <tr>
                                            <th>Firstname</th>
                                            <th>Lastname</th>
                                            <th>Age</th>
                                        </tr>
                                        {ingridients.map((item, index) => {
                                            return (
                                                <tr key={index}>
                                                    <th><img src={'https://spoonacular.com/cdn/ingredients_100x100/' + item.image} className="d-block w-100" alt="ingrid" /></th>
                                                    <th>{item.name}</th>
                                                    <th>{item.amount.metric.value}</th>
                                                </tr>
                                                // <li key={index} className="list-group-item text-slanted">
                                                //     {item.amount.metric.value}
                                                // </li>
                                            );
                                        })}
                                    </table>
                                </div>
                            </div> */}
								<div className="accor">
									<div className="head" onClick={this.onClickIngridients}> Ingredients</div>
									<div className="body" id="ingridients">
									</div>
								</div>
								<div className="accor">
									<div className="head" onClick={this.onClickEquipment}> Equipment</div>
									<div className="body" id="equipment">
									</div>
								</div>
								<div className="accor">
									<div className="head" onClick={this.onClickSteps}> Steps</div>
									<div className="body" id="steps">
										{
											this.state.stepsArray.length > 0 ? this.state.stepsArray.map((s, index) => {
												return (<div key={index} className="steps">
													<div className="steps-title">{s.name} </div>
													<div className="instruction">
														{s.steps.map((x, i) => {
															return <p key={i}>{x.number}. {x.step}</p>
														})

														}
													</div>
												</div>);

											}) : ""
										}
									</div>
								</div>
							</Accordion>
						</div>
					</div>
				</div>
			</React.Fragment>
		);
	}
	// }
}