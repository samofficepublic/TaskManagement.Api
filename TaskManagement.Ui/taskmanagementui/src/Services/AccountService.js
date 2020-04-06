import axiosConfig from "../AxiosConfig/base";

const Api_Login = async user => {
  return axiosConfig
    .post("v1/UserAccount/TokenByEmail", user)
    .then(async response => {
      return response;
    })
    .catch(async exception => {
      return Promise.reject(exception);
    });
};

export { Api_Login };
