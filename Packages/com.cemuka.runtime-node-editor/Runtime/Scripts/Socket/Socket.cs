using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor
{
    public abstract class Socket : MonoBehaviour
    {
        public Node             OwnerNode { get { return _ownerNode; } }
        public ISocketEvents    Events    { get { return _socketEvents; } }
        public IReadOnlyList<Connection> Connections { get { return _connections; } }
        
        public string           socketId;
        public SocketHandle     handle;
        public ConnectionType   connectionType;
        private Node            _ownerNode;
        private ISocketEvents   _socketEvents;
        private List<Connection> _connections = new List<Connection>();

        public void SetOwner(Node owner, ISocketEvents events)
        {
            _ownerNode = owner;
            _socketEvents = events;
        }

        public void Connect(Connection conn)
        {
            _connections.Add(conn);
        }

        public void Disconnect(Connection conn)
        {
            _connections.Remove(conn);
        }

        public bool HasConnection()
        {
            return Connections.Count > 0;
        }
    }
}