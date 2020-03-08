import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Table, Row, Col, Container } from "react-bootstrap";

class Tickets extends Component {
  render() {
    return (
      <Container fluid>
        <Row>
          <Col md={{ span: 1 }}> </Col>
          <Col md={{ span: 10, offset: 3 }}>
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th> #</th>
                  <th>First Name</th>
                  <th>Last Name</th>
                  <th>Username</th>
                  <th>عملیات</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>1</td>
                  <td>Mark</td>
                  <td>Otto</td>
                  <td>@mdo</td>
                </tr>
                <tr>
                  <td>2</td>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <td>3</td>
                  <td colSpan="2">Larry the Bird</td>
                  <td>@twitter</td>
                </tr>
              </tbody>
            </Table>
          </Col>
        </Row>
      </Container>
    );
  }
}

export default withRouter(Tickets);
