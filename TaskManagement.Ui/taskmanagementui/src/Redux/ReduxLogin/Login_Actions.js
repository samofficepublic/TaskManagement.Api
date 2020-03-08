const Login = "LOGIN";
const LogOut = "LOGOUT";

const Login_Action = user => ({ type: Login, user });

const LogOut_Action = () => ({
  type: LogOut
});

export { Login, LogOut, Login_Action, LogOut_Action };
