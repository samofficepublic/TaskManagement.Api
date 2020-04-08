import React from "react";
import { withRouter } from "react-router-dom";

function ServiceBroken(props) {
  switch (props.match.params.exception) {
    case "-1": {
      return <h1>your connection failed....Please try again later</h1>;
    }
    default:
      return <h1>{props.match.params.exception}</h1>;
  }
}

export default withRouter(ServiceBroken);
