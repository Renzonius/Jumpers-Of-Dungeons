using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Message
{
    public string Text;
    public Text TextObject;
    public MessageType MessageType;
}

public enum MessageType
{
    User, Bot
}

public class BotDialog : Dialog
{
    [Expression("Hola")]
    public void Hello(Context context, Result result)
    {
        result.SendResponse("¡Hola jugador!. " +
            "¿En que te ayudo?" +
            "¿Necesitas saber sobre los controles?. ¿Sobre la historia o el objetivo del juego?");
    }

    [Expression("Controles")]
    public void Controles(Context context, Result result)
    {
        result.SendResponse("Las teclas predeterminadas para el JUGADOR UNO son: W,S para el movimiento y la tecla E para interacturar. " +
            "Para el JUGADOR DOS son: I,K para el movimiento y la tecla U para interactuar.");
    }

    [Expression("Cual es el objetivo?")]
    public void Objetivo(Context context, Result result)
    {
        result.SendResponse("El objetivo del juego es tratar de recolectar la mayor cantidad de tesoros, acumulando puntos y evitando " +
            "ser alcanzados por la bola de fuego que viene persiguiendolos, ademas de esquivar trampas y obstaculos para poder escapar.");
    }

    [Expression("Quiero saber cual es la historia")]
    public void Historia(Context context, Result result)
    {
        result.SendResponse("En el año 1512 existieron ruinas, mazmorras, cavernas y templos en los cuales se encontraban muchos tesoros," +
            " protegidos por feroces bestias. Los únicos que se animaban a entrar, pertenecían a la Hermandad de Ladrones." +
            "Si de robar se trata, "+"Bucku y Tuxxi son los mejores. " +
            "Serán los personajes de esta historia, quienes se adentraron en las ruinas del castillo Beltramo en busca " +
            "de la pieza faltante de un mapa el cual rebelara ubicaciones de tesoros muy valiosos. ¿Serán capaces de lograrlo?");
    }

    [Expression("Adios")]
    public void Despedir(Context context, Result result)
    {
        result.SendResponse("¡Que disfrutes del juego! :)");
    }


}

public class GameManager : MonoBehaviour
{
    OscovaBot MainBot;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    public Color UserColor, BotColor;

    List<Message> Messages = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            MainBot = new OscovaBot();
            OscovaBot.Logger.LogReceived += (s, o) =>
            {
                Debug.Log($"OscovaBot: {o.Log}");
            };

            MainBot.Dialogs.Add(new BotDialog());
            //MainBot.ImportWorkspace("Assets/bot-kb.west");
            MainBot.Trainer.StartTraining();

            MainBot.MainUser.ResponseReceived += (sender, evt) =>
            {
                AddMessage($"Bot: {evt.Response.Text}", MessageType.Bot);
            };
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    public void AddMessage(string messageText, MessageType messageType)
    {
        if (Messages.Count >= 25)
        {
            //Remove when too much.
            Destroy(Messages[0].TextObject.gameObject);
            Messages.Remove(Messages[0]);
        }

        var newMessage = new Message { Text = messageText };

        var newText = Instantiate(textObject, chatPanel.transform);

        newMessage.TextObject = newText.GetComponent<Text>();
        newMessage.TextObject.text = messageText;
        newMessage.TextObject.color = messageType == MessageType.User ? UserColor : BotColor;

        Messages.Add(newMessage);
    }

    public void SendMessageToBot()
    {
        var userMessage = chatBox.text;

        if (!string.IsNullOrEmpty(userMessage))
        {
            Debug.Log($"OscovaBot:[USER] {userMessage}");
            AddMessage($"User: {userMessage}", MessageType.User);
            var request = MainBot.MainUser.CreateRequest(userMessage);
            var evaluationResult = MainBot.Evaluate(request);
            evaluationResult.Invoke();

            chatBox.Select();
            chatBox.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToBot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Titulo");
        }
    }
}