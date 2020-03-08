import AxiosConfig from "../AxiosConfig/base";
import axiosConfig from "../AxiosConfig/base";

const Get = async () => {
  return axiosConfig
    .get("/v1/Ticket/Get")
    .then(async response => {
      return response;
    })
    .catch(async error => {
      let exception = error.response;
      return Promise.reject(exception);
    });
};
