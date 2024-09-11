import { StrictMode, useEffect, useState } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import { js } from "@eslint/js";

const viaCepUrl = "https://viacep.com.br/ws";

const commonStyles = {
  container: {
    height: "100vh",
    width: "60%",
  },
  inputContainer: {
    display: "flex",
    gap: "10px",
    marginBottom: "20px",
  },
  labelInputWrapper: {
    display: "flex",
    gap: "4px",
    alignItems: "center",
  },
  dataFieldContainer: {
    display: "flex",
    gap: "4px",
    width: "300px",
    justifyContent: "space-between",
  },
  dataFieldColumn: {
    display: "flex",
    gap: "4px",
    flexDirection: "column",
  },
  labelStyle: {
    fontWeight: "bold",
  },
};

const DisplayDataField = ({ label, displayData }) => {
  return (
    <div style={commonStyles.dataFieldContainer}>
      <label style={commonStyles.labelStyle}>{label}</label>
      <input disabled value={displayData ?? "Não informado"} />
    </div>
  );
};

const AdressDataDisplay = ({ addressInfo }) => {
  return (
    <div style={commonStyles.dataFieldColumn}>
      <DisplayDataField label="CEP" displayData={addressInfo?.cep ?? "-"} />
      <DisplayDataField
        label="Logradouro"
        displayData={addressInfo?.logradouro ?? "-"}
      />
      <DisplayDataField
        label="Complemento"
        displayData={addressInfo?.complemento ?? "-"}
      />
      <DisplayDataField
        label="Unidade"
        displayData={addressInfo?.unidade ?? "-"}
      />
      <DisplayDataField
        label="Bairro"
        displayData={addressInfo?.bairro ?? "-"}
      />
      <DisplayDataField
        label="Localidade"
        displayData={addressInfo?.localidade ?? "-"}
      />
      <DisplayDataField label="UF" displayData={addressInfo?.uf ?? "-"} />
      <DisplayDataField
        label="Região"
        displayData={addressInfo?.regiao ?? "-"}
      />
      <DisplayDataField label="IBGE" displayData={addressInfo?.ibge ?? "-"} />
      <DisplayDataField label="GIA" displayData={addressInfo?.gia ?? "-"} />
      <DisplayDataField label="DDD" displayData={addressInfo?.ddd ?? "-"} />
      <DisplayDataField label="SIAFI" displayData={addressInfo?.siafi ?? "-"} />
    </div>
  );
};

const AddressPage = () => {
  const [addressInfo, setAddressInfo] = useState(null);
  const [cep, setCep] = useState(null);

  const fetchAddress = async () => {
    if (!cep || cep.trim().length !== 8) {
      return;
    }

    try {
      const response = await fetch(`${viaCepUrl}/${cep}/json`);
      setAddressInfo(await response.json());
    } catch (e) {
      setAddressInfo(null);
      alert(e.message);
    }
  };

  useEffect(() => {
    console.log("cep mudou, chamando o fetch address");
    fetchAddress();

    return () => {
      console.log("COmponente desmontado");
    };
  }, [cep]);

  return (
    <div style={commonStyles.container}>
      <div style={commonStyles.inputContainer}>
        <div style={commonStyles.labelInputWrapper}>
          <label style={commonStyles.labelStyle}>CEP</label>
          <input
            value={cep}
            type="text"
            onChange={(e) => setCep(e.target.value)}
          />
        </div>
        <button onClick={fetchAddress}>Buscar</button>
      </div>
      <AdressDataDisplay addressInfo={addressInfo} />
    </div>
  );
};

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <AddressPage />
  </StrictMode>
);
