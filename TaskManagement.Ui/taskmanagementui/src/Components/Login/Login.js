import React, { Component } from "react";
import { Card, Button, Form, Row, Col, Image } from "react-bootstrap";
import loginlogo from "../../Images/LoginLogo.png";
import { withRouter } from "react-router-dom";
import { connect } from "react-redux";
import * as Actions from "../../Redux/ReduxLogin/Login_Actions";
import { Api_Login } from "../../Services/AccountService";
import Dialog from "react-bootstrap-dialog";

class Login extends Component {
  txtEmail = "";
  txtPass = "";
  GoLogin = async () => {
    let data = {
      Email: this.txtEmail.value,
      password: this.txtPass.value
    };

    if (data.Email !== "" && data.password !== "" && data.Email.includes("@")) {
      let response = await Api_Login(data);
      console.log(response);
      this.props.login(response.data);
      this.props.history.push("/home");
    } else {
      this.dialog.show({
        title: "خطا",
        body: "خطا در ورود اطلاعات ضروری",
        actions: [Dialog.OKAction()],
        bsSize: "medium",
        onHide: dialog => {
          dialog.hide();
        }
      });
    }
  };

  render() {
    return (
      <Form>
        <Form.Row>
          <Col md="4"></Col>
          <Card as={Col} md="4">
            <Row>
              <Col md="4"></Col>
              <Col md="4">
                <Image
                  src={loginlogo}
                  width="100"
                  style={{
                    marginTop: "2px",
                    marginBottom: "2px"
                  }}
                />
              </Col>
              <Col md="4"></Col>
            </Row>
            <Form.Group controlId="formGridEmail">
              <Form.Control
                placeholder="ایمیل"
                type="email"
                ref={el => (this.txtEmail = el)}
              />
            </Form.Group>
            <Form.Group controlId="FormGridPassword">
              <Form.Control
                type="password"
                placeholder="رمز عبور"
                ref={el => (this.txtPass = el)}
              />
            </Form.Group>

            <Form.Group controlId="Button">
              <Button size="lg" variant="primary" onClick={this.GoLogin} block>
                ورود
              </Button>
              <Dialog
                ref={component => {
                  this.dialog = component;
                }}
              />
            </Form.Group>
          </Card>
          <Col md="4"></Col>
        </Form.Row>
      </Form>
    );
  }

  componentDidMount() {
    if (this.props.userState.access_token != null) {
      this.props.history.push("/home");
    }
  }
}

const mapDispatchToProps = dispatch => {
  return {
    login: user => dispatch(Actions.Login_Action(user))
  };
};

const mapStateToProps = state => {
  return {
    userState: state.Login_Reducer.user
  };
};

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Login));
