import React, { Component } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login/Login";
import NotFound from "./NotFound/NotFound";
import Home from "./Home/Home";
import { connect } from "react-redux";
import Tickets from "./Ticket/Tickets";
import LoginedNavs from "./Navigations/LoginedNavs";
import NoLoginedNavs from "./Navigations/NoLoginedNavs";

class BaseComponent extends Component {
  GetRoute = () => {
    let routes = null;
    let navs = null;

    let loginInfo = this.props.userLogedIn;
    let isLogin = loginInfo ? loginInfo.access_token : "";

    if (isLogin) {
      routes = (
        <Switch>
          <Route exact path="/" component={Login} />
          <Route path="/login" component={Login} />
          <Route path="/home" component={Home} />
          <Route path="/Tickets" component={Tickets} />
          <Route path="/404" component={NotFound} />
          <Redirect to="/404" />
        </Switch>
      );
      navs = LoginedNavs();
    } else {
      routes = (
        <Switch>
          <Route exact path="/" component={Login} />
          <Route path="/login" component={Login} />
          <Route path="/404" component={NotFound} />
          <Redirect to="/404" />
        </Switch>
      );
      navs = NoLoginedNavs();
    }
    return {
      routes,
      navs
    };
  };

  render() {
    console.log("base Rendered...");

    const { routes, navs } = this.GetRoute();

    console.log(routes);

    return (
      <div>
        <div>{navs}</div>
        {routes}
      </div>
    );
  }
}

const mapStateToProps = state => {
  return {
    userLogedIn: state.Login_Reducer.user
  };
};

export default connect(mapStateToProps, null)(BaseComponent);
