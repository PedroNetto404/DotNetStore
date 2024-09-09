const BASE_URL = "https://localhost:7206";

const fetchHello = async () => {
  const response = await fetch(`${BASE_URL}/hello-world`);

  const data = JSON.parse(await response.json());
  console.log(data);

  document.querySelector("#fetchHelloResponse").innerText = data.Message;
};

document.querySelector("#fetchHello").addEventListener("click", fetchHello);
