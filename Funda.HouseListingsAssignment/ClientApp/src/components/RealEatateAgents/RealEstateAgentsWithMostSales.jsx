import React, { Component } from "react";
import axios from 'axios';

export default class RealEstateAgentsWithMostSales extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            searchOptions: this.props.searchOptions,
            EstateAgentsData: []
        }
    }

    componentDidMount() {
        this.fetchAgentsBySales();
    }

    componentDidUpdate(prevProps) {
        if (this.props.searchOptions.isTuin != prevProps.searchOptions.isTuin) {
            this.fetchAgentsBySales();
        }
    }

    fetchAgentsBySales() {
        var { city, additionalSerach, type } = this.props.searchOptions;
        var url = "https://localhost:5001/api/getagents/" + `${city}${additionalSerach !== "" ? "/" + additionalSerach : ""}/${type}`;

        axios.get(url).then(response => {
            this.setState({
                EstateAgentsData: response.data
            });
        });
    }

    render() {
        return (
            <>
                <h1>Real Estate Agent's By Sale Offers</h1>
                <div>
                    <table>
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Real Eatate Agent</th>
                                <th>Property Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.EstateAgentsData.map((p, index) => {
                                    return <tr key={index}><td>{p.makelaarId}</td><td> {p.makelaarNaam}</td><td>{p.estateCount}</td></tr>;
                                })
                            }
                        </tbody>
                    </table>
                </div> 
            </>
        );
    }
}