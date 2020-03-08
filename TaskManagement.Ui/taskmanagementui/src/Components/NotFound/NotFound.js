import React, { Component } from "react";
import image from "../../Images/404-IMG.jpg";
import "./NotFound.css";

class NotFound extends Component {
  render() {
    return (
      <div>
        <img src={image} alt="صفحه مورد نظر پیدا نشد" className="image" />
      </div>
    );
  }
}

export default NotFound;
