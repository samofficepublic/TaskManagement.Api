import React from "react";
import { Nav, Navbar } from "react-bootstrap";

const NoLoginednavs = () => {
  return (
    <Navbar bg="light" expand="lg">
      <Navbar.Brand href="/home">سیستم تیکتینگ</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-right">
          <Nav.Link href="/login">ورود</Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
};

export default NoLoginednavs;
