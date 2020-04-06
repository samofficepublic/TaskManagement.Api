const GET = "GET";
const ADDNEWTICKET = "ADDNEWTICKET";

const Get_Action = ticket => ({
  type: GET,
  ticketItems: ticket
});

const AddNewTicket_Action = ticket => ({
  type: ADDNEWTICKET,
  ticketItem: ticket
});

export { GET, Get_Action, ADDNEWTICKET, AddNewTicket_Action };
