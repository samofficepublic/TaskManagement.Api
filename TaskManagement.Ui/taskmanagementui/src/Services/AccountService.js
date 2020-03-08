import axiosConfig from "../AxiosConfig/base";
import apiStatusCodeCheck from "../utility/apiStatusCodeCheck";

const Api_Login = async user => {
  return axiosConfig
    .post("v1/UserAccount/TokenByEmail", user)
    .then(async response => {
      console.log(response);
      return response;
    })
    .catch(exception => {
      let catchResponse = exception.response;
      console.log(catchResponse);
      alert(apiStatusCodeCheck(catchResponse.status));
      return Promise.reject(exception);
    });
};

export { Api_Login };
