import { useState } from "react";
import axios from "axios";

function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [token, setToken] = useState("");

  const login = async () => {
    try {
      const response = await axios.post(
        "http://localhost:5131/api/auth/login",
        {
          username: username.trim(),
          password: password.trim(),
        }
      );

      const jwt = response.data.accessToken;
      localStorage.setItem("token", jwt);
      setToken(jwt);

      alert("Login successful ✅");
    } catch (error) {
      alert("Invalid credentials ❌");
    }
  };

  return (
    <div style={{ padding: "40px" }}>
      <h2>Login</h2>

      <input
        type="text"
        placeholder="Username"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />

      <br /><br />

      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <br /><br />

      <button onClick={login}>Login</button>

      {token && <p>Token stored ✅</p>}
    </div>
  );
}

export default Login;
