import React from "react";
import {
  Nav,
  Navbar,
  NavDropdown,
  Form,
  Button,
  FormControl
} from "react-bootstrap";
import { Link } from "react-router-dom";

const LoginedNavs = () => {
  return (
    <Navbar bg="light" expand="lg">
      <Link to="/home">
        <Navbar.Brand>سیستم تیکتینگ </Navbar.Brand>
      </Link>

      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-right">
          <span>
            <Link to="/tickets"> لیست تیکتها </Link>
          </span>
        </Nav>
        <Nav className="mr-auto">
          <Link to="/SignOut">خروج</Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
};
export default LoginedNavs;
