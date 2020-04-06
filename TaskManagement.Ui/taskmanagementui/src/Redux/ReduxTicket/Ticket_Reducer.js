import * as Actions from "./Ticket_Actions";
const initialState = {
  ticket: {}
};

const Ticket_Recucer = (state = initialState, action) => {
  switch (action.type) {
    case Actions.GET:
      return Get(state, action.ticketItems);
    case Actions.ADDNEWTICKET:
      return AddNewTicket(state, action.ticketItem);
    default:
      break;
  }
  return state;
};

export default Ticket_Recucer;

const Get = (state, ticket) => {
  return {
    ...state,
    ticket
  };
};

const AddNewTicket = (state, ticket) => {
  console.log({ ...state });
  console.log({
    ...state,
    ticket
  });

  return {
    ...state,
    ticket
  };
};
