import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import {
  Table,
  Container,
  Pagination,
  Col,
  Row,
  Button,
  Modal,
  Form
} from "react-bootstrap";
import {
  Ticket_Get,
  Ticket_AddNewTicket,
  Ticket_EditTicket,
  Ticket_DeleteTicket
} from "../../Services/TicketService";
import * as Actions from "../../Redux/ReduxTicket/Ticket_Actions";
import { connect } from "react-redux";
import moment from "jalali-moment";

const rowCount = 10;

class Tickets extends Component {
  constructor(props) {
    super(props);
    this.state = {
      curentPage: 1,
      modalVisibility: false,
      operation: "ins",
      currentTicket: null
    };
    this.handlePageNumberChange = this.handlePageNumberChange.bind(this);
    this.handleShowInfo = this.handleShowInfo.bind(this);
  }
  subject = "";
  description = "";

  GetTickets = async page => {
    console.log(page);
    let result = await Ticket_Get(page, rowCount);
    if (result.data.apiResultStatusCode === 0) {
      this.props.Get_Dispatch(result.data.data);
      this.setState({ curentPage: page });
    }
  };

  handlePrevPage = () => {
    let currentPage = this.state.curentPage;
    let prevPage = currentPage - 1;
    if (prevPage > 0) {
      this.GetTickets(prevPage);
    }
  };

  handleNextPage = () => {
    let currentPage = this.state.curentPage;
    let nextPage = currentPage + 1;
    if (rowCount <= this.props.ticket.length) {
      this.GetTickets(nextPage);
    }
  };

  handleDeleteTicket = async ticket => {
    console.log(ticket);
    this.setState({ operation: "del" });
    let result = await Ticket_DeleteTicket(ticket);
    if (result.data.apiResultStatusCode === 0) {
      this.GetTickets(this.state.curentPage);
    }
  };

  renderRows = () => {
    if (this.props.ticket.length > 0) {
      let items = this.props.ticket.map((item, key) => (
        <tr style={{ textAlign: "center" }} key={key}>
          <td style={{ textAlign: "center" }}>{item.id}</td>
          <td style={{ textAlign: "center" }}>{item.subject}</td>
          <td style={{ textAlign: "center" }}>
            {moment(item.createDate, "YYYY/MM/DD")
              .locale("fa")
              .format("YYYY/MM/DD")}
          </td>
          <td style={{ textAlign: "center" }}>
            <Button
              variant="info"
              size="sm"
              onClick={() => this.handleShowInfo(item)}
            >
              جزئیات
            </Button>{" "}
            <Button
              variant="warning"
              size="sm"
              onClick={() => this.handleUpdateTicket(item)}
            >
              ویرایش
            </Button>{" "}
            <Button
              variant="danger"
              size="sm"
              onClick={() => this.handleDeleteTicket(item)}
            >
              حذف
            </Button>
          </td>
        </tr>
      ));
      return items;
    }
  };

  handleUpdateTicket = ticket => {
    this.setState({
      operation: "upd",
      currentTicket: ticket,
      modalVisibility: true
    });
  };

  handleShowInfo(ticket) {
    console.log(ticket);
    this.setState({
      currentTicket: ticket,
      operation: "show",
      modalVisibility: true
    });
  }

  handlePageNumberChange(e) {
    // let currentPage = this.state.curentPage;
    let requestPage = parseInt(e.target.value);
    if (requestPage > 0) {
      this.GetTickets(requestPage);
    }
  }

  handleCloseModal = () => {
    this.setState({ modalVisibility: false });
  };

  AddNewTicket = async () => {
    if (this.state.operation === "ins") {
      let ticket = {
        subject: this.subject.value,
        description: this.description.value
      };
      let result = await Ticket_AddNewTicket(ticket);
      if (result.data.apiResultStatusCode === 0) {
        this.handleCloseModal();
        this.GetTickets(this.state.curentPage);
      }
    } else if (this.state.operation === "upd") {
      let ticket = {
        id: this.state.currentTicket.id,
        subject: this.subject.value,
        description: this.description.value
      };
      let updateResult = await Ticket_EditTicket(ticket);
      if (updateResult.data.apiResultStatusCode === 0) {
        this.handleCloseModal();
        this.GetTickets(this.state.curentPage);
      }
    }
  };

  handleModalOperation = () => {
    if (this.state.operation === "ins") {
      return (
        <Form>
          <Form.Group controlId="exampleForm.ControlInput1">
            <Form.Control
              type="text"
              placeholder="موضوع"
              ref={e => (this.subject = e)}
            />
          </Form.Group>

          <Form.Group controlId="exampleForm.ControlTextarea1">
            <Form.Control
              placeholder="شرح"
              as="textarea"
              rows="3"
              ref={e => (this.description = e)}
            />
          </Form.Group>
        </Form>
      );
    } else if (this.state.operation === "show") {
      return (
        <Form>
          <Form.Group controlId="exampleForm.ControlInput1">
            <Form.Control
              type="text"
              placeholder="موضوع"
              defaultValue={this.state.currentTicket.subject}
              ref={e => (this.subject = e)}
            />
          </Form.Group>
          <Form.Group controlId="exampleForm.ControlTextarea1">
            <Form.Control
              placeholder="شرح"
              as="textarea"
              rows="3"
              defaultValue={this.state.currentTicket.description}
              ref={e => (this.description = e)}
            />
          </Form.Group>
        </Form>
      );
    } else if (this.state.operation === "upd") {
      return (
        <Form>
          <Form.Group controlId="exampleForm.ControlInput1">
            <Form.Control
              type="text"
              placeholder="موضوع"
              defaultValue={this.state.currentTicket.subject}
              ref={e => (this.subject = e)}
            />
          </Form.Group>
          <Form.Group controlId="exampleForm.ControlTextarea1">
            <Form.Control
              placeholder="شرح"
              as="textarea"
              rows="3"
              defaultValue={this.state.currentTicket.description}
              ref={e => (this.description = e)}
            />
          </Form.Group>
        </Form>
      );
    }
  };

  render() {
    return (
      <Container fluid="md">
        <Modal
          centered
          show={this.state.modalVisibility}
          onHide={this.handleCloseModal}
        >
          <Modal.Header>
            <Modal.Title>تیکت جدید</Modal.Title>
          </Modal.Header>
          <Modal.Body>{this.handleModalOperation()}</Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={this.handleCloseModal}>
              انصراف
            </Button>
            {this.state.operation === "ins" ||
            this.state.operation === "upd" ? (
              <Button variant="primary" onClick={this.AddNewTicket}>
                ذخیره اطلاعات
              </Button>
            ) : (
              ""
            )}
          </Modal.Footer>
        </Modal>
        <Row>
          <Col>
            <Button
              variant="primary"
              onClick={() =>
                this.setState({ modalVisibility: true, operation: "ins" })
              }
            >
              تیکت جدید
            </Button>
          </Col>
        </Row>
        <Table responsive striped bordered hover>
          <thead>
            <tr>
              <th style={{ textAlign: "center" }} width="140px">
                شماره تیکت
              </th>
              <th style={{ textAlign: "center" }}>موضوع</th>
              <th style={{ textAlign: "center" }} width="140px">
                تاریخ ارسال
              </th>
              <th style={{ textAlign: "center" }} width="200">
                عملیات
              </th>
            </tr>
          </thead>
          <tbody>{this.renderRows()}</tbody>
        </Table>
        <Row>
          <Col md={4}></Col>
          <Col md={4}>
            <Pagination center="true" size="sm">
              <Pagination.Prev onClick={() => this.handlePrevPage()} />
              <input
                type="text"
                style={{ width: "70px", textAlign: "center" }}
                value={this.state.curentPage}
                onChange={this.handlePageNumberChange}
              />

              <Pagination.Next onClick={() => this.handleNextPage()} />
            </Pagination>
          </Col>
          <Col md={4}></Col>
        </Row>
      </Container>
    );
  }

  componentDidMount() {
    this.GetTickets(this.state.curentPage);
  }

  componentDidUpdate(newProps, newState) {
    if (
      newState.curentPage !== this.state.curentPage &&
      this.state.curentPage > 0
    ) {
      this.GetTickets(this.state.curentPage);
    }
  }
}

const mapStateToProps = state => {
  return { ticket: state.Ticket_Reducer.ticket };
};

const mapDispatchToProps = dispatch => {
  return {
    Get_Dispatch: tickets => dispatch(Actions.Get_Action(tickets)),
    AddNewTicket_Dispatch: ticket =>
      dispatch(Actions.AddNewTicket_Action(ticket))
  };
};

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(Tickets)
);
