import axiosConfig from "../AxiosConfig/base";

const Ticket_Get = async (page, pageSize) => {
  return axiosConfig
    .get("/v1/Ticket/Get?page=" + page + "&pageSize=" + pageSize)
    .then(async response => {
      return response;
    })
    .catch(async error => {
      return Promise.reject(error);
    });
};

const Ticket_AddNewTicket = async ticket => {
  return axiosConfig
    .post("/v1/ticket/AddNewTicket", ticket)
    .then(async response => {
      return response;
    })
    .catch(async error => {
      return Promise.reject(error);
    });
};

const Ticket_GetById = ticketId => {
  axiosConfig
    .get("v1/ticket/GetById", ticketId)
    .then(async response => {
      return response;
    })
    .catch(error => {
      return Promise.reject(error);
    });
};

const Ticket_EditTicket = async ticket => {
  return axiosConfig
    .put("/v1/ticket/EditTicket", ticket)
    .then(async response => {
      return response;
    })
    .catch(async error => {
      return Promise.reject(error);
    });
};

const Ticket_DeleteTicket = async ticket => {
  return axiosConfig
    .post("/v1/ticket/DeleteTicket", ticket)
    .then(async response => {
      return response;
    })
    .catch(async error => {
      return Promise.reject(error);
    });
};

export {
  Ticket_Get,
  Ticket_GetById,
  Ticket_AddNewTicket,
  Ticket_EditTicket,
  Ticket_DeleteTicket
};
