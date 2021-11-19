import React from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Provider } from "react-redux";
import {Dashboard, Header} from "./Components";
import Routes from "./Components/Routes";
import store from "./Store";

function App() {
  
  return (
    <Provider store={store}>
    <Router>
      <Header/>
      <Switch>
        <Route exact path="/" component={Dashboard}/>
        <Route component={Routes} />
      </Switch>
    </Router>
    </Provider>
  )
}

export default App

