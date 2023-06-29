using RPG.Equipment.Items;
using RPG.Equipment.Materials;
using RPG.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stores
{
    public class StoreControler : MonoBehaviour, ICloseableUIElement
    {

        [SerializeField] public GameObject buyPanelControler;
        public BuyPanelControler buyPanelControlerScript; 
        [SerializeField] public GameObject sellPanelControler;
        public SellPanelControler sellPanelControlerScript;
        
        [SerializeField] public GameObject buyPanel;
        [SerializeField] public GameObject sellPanel;
        
        private PlayerGold playerGold;

        private void Start()
        {
            playerGold = GameObject.FindGameObjectWithTag("GoldControler").GetComponent<PlayerGold>();
            buyPanelControlerScript = buyPanelControler.GetComponent<BuyPanelControler>();
            sellPanelControlerScript = sellPanelControler.GetComponent<SellPanelControler>();
        }
        public void OpenStorePanel()
        {
            GameObject.FindWithTag("CanvasManager").GetComponent<CanvasManager>().CloseAllWindows();
            GetComponent<Canvas>().enabled = true;
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        }

        public void CloseStorePanel()
        {
            GetComponent<Canvas>().enabled = false;
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            buyPanelControlerScript.ResetStorePanel();
        }

        public void Close()
        {
            CloseStorePanel();
        }

        public void BuyPanelButton()
        {
            sellPanel.SetActive(false);
            buyPanel.SetActive(true);
        }

        public void SellPanelButton()
        {
            buyPanel.SetActive(false);
            sellPanel.SetActive(true);
            sellPanel.GetComponent<SellPanelControler>().InitializeSellPanel();
        }
        
    }   
}

















