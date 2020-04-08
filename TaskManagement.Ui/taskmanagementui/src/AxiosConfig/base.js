import axios from "axios";
import { withRouter } from "react-router-dom";

const axiosConfig = axios.create({
  baseURL: "https://localhost:5001/api/",
  headers: {
    "Content-Type": "application/json"
  }
});

axiosConfig.interceptors.request.use(
  async request => {
    let token = JSON.parse(localStorage.getItem("LoginInfo"));
    if (token != null) {
      request.headers.Authorization = "Bearer " + token.access_token;
    }
    return request;
  },
  async error => {
    return Promise.reject(error);
  }
);

axiosConfig.interceptors.response.use(
  async response => {
    return response;
  },
  async error => {
    if (error.response) {
      console.log(error.response);
      let exception = error.response.status;
      await processApiException(exception);
    }
    await processApiException(-1);
    return Promise.reject(error);
  }
);

const processApiException = async exception => {
  switch (exception) {
    case -1: {
      window.location.href = "/ServiceBroken/" + exception;
      break;
    }
    case 401: {
      localStorage.removeItem("LoginInfo");
      window.location.href = "/login";
      break;
    }

    default:
      window.location.href = "/ServiceBroken/" + exception;
      break;
  }
  return Promise.reject(exception);
};

export default withRouter(axiosConfig);
