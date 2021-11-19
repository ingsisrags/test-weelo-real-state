import React from 'react';
import { Route, Switch } from 'react-router-dom';
import {NotFound} from "./Layout";
import {ProductDetails, ProductIndex} from "./Product";

const Routes = props => {
    return (
        <section className="container">
            <Switch>
                <Route exact path="/product/:id" component={ProductDetails} />
                <Route exact path="/create-product/" component={ProductIndex} />
                <Route component={NotFound} />
            </Switch>
        </section>
    );
};

export default Routes;
