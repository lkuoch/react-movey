import React from "react";
import { Router, Route, Switch } from "react-router-dom";
import "semantic-ui-css/semantic.min.css";
import "../styles/main.css";

import Header from "./header/Header";
import History from "../navigation/History";
import Home from "./movies/Home";

function App() {
  return (
    <div className="app-container">
      <Router history={History}>
        <>
          <Header />
          <Switch>
            <Route exact path="/" component={Home} />
          </Switch>
        </>
      </Router>
    </div>
  );
}

export default App;
