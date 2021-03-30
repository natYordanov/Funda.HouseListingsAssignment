import React, { Component } from 'react';
import RealEstateAgentsWithMostSales from './RealEatateAgents/RealEstateAgentsWithMostSales';

export class Home extends Component {
    constructor() {
        super();
        this.state = {
            isTuin: false,
            type: "koop",
            city: "amsterdam",
            additionalSerach: ""
        }

        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.checked;
        const name = target.name;

        this.setState({
            [name]: value
        });

        if (value) {
            this.setState({ additionalSerach: "tuin" });
        }
        else {
            this.setState({ additionalSerach: "" });
        }
    }

  render () {
    return (
        <div>
            <input type="checkbox" value="koop" id="koopType" checked disabled />
            <label> Koop</label><br />
            <input type="checkbox" value="amsterdam" id="amsterdam" checked disabled/>
            <label> Amsterdam</label><br/>
            <input name="isTuin" type="checkbox" checked={this.state.isTuin} onChange={this.handleInputChange} />
            <label> Tuin</label>
            <RealEstateAgentsWithMostSales searchOptions={this.state} />
      </div>
    );
  }
}
