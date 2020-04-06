import React from "react";
import { Nav, Navbar } from "react-bootstrap";
import { Link } from "react-router-dom";

const LoginedNavs = () => {
  return (
    <Navbar bg="light" expand="lg">
      <Link to="/home">
        <Navbar.Brand>سیستم تیکتینگ </Navbar.Brand>
      </Link>

      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-right">
          <span>
            <Link to="/tickets"> لیست تیکتها </Link>
          </span>
        </Nav>
        <Nav className="mr-auto">
          <Link to="/SignOut">خروج</Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
};
export default LoginedNavs;

// import React, { Component } from "react";
// import { Layout, Menu, Breadcrumb } from "antd";
// const { Header, Content, Footer } = Layout;

// class LoginedNavs extends Component {
//   render() {
//     return (
//       <Layout className="layout">
//         <Header>
//           <div className="logo" />
//           <Menu
//             theme="dark"
//             mode="horizontal"
//             defaultSelectedKeys={["2"]}
//             style={{ lineHeight: "64px" }}
//           >
//             <Menu.Item key="1">nav 1</Menu.Item>
//             <Menu.Item key="2">nav 2</Menu.Item>
//             <Menu.Item key="3">nav 3</Menu.Item>
//           </Menu>
//         </Header>
//         <Content style={{ padding: "0 50px" }}>
//           <Breadcrumb style={{ margin: "16px 0" }}>
//             <Breadcrumb.Item>Home</Breadcrumb.Item>
//             <Breadcrumb.Item>List</Breadcrumb.Item>
//             <Breadcrumb.Item>App</Breadcrumb.Item>
//           </Breadcrumb>
//           <div className="site-layout-content">Content</div>
//         </Content>
//         <Footer style={{ textAlign: "center" }}>
//           Ant Design ©2018 Created by Ant UED
//         </Footer>
//       </Layout>
//     );
//   }
// }

// export default LoginedNavs;
