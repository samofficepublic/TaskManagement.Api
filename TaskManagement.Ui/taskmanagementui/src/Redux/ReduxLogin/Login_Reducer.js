import * as Actions from "./Login_Actions";

const initialState = {
  user: {}
};

let LoginedUser = JSON.parse(localStorage.getItem("LoginInfo"));

if (LoginedUser != null) {
  initialState["user"] = LoginedUser;
} else {
  initialState["user"] = {};
}

const LoginReducer = (state = initialState, action) => {
  switch (action.type) {
    case Actions.Login:
      return Login(state, action.user);
    case Actions.LogOut:
      return LogOut(state);

    default:
      break;
  }
  return state;
};

const Login = (state, user) => {
  localStorage.setItem("LoginInfo", JSON.stringify(user));

  return {
    ...state,
    user
  };
};

const LogOut = state => {
  localStorage.removeItem("LoginInfo");
  return {
    state,
    user: {}
  };
};

export default LoginReducer;
