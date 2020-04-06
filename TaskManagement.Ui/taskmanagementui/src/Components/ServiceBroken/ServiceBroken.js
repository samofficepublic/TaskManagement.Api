import React from "react";
import { withRouter } from "react-router-dom";

function ServiceBroken(props) {
  return <h1>{props.match.params.exception}</h1>;
}

export default withRouter(ServiceBroken);
