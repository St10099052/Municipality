using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BinarySearchTree
{
    public class TreeNode
    {
        public ServiceRequest Request;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(ServiceRequest request)
        {
            Request = request;
            Left = Right = null;
        }
    }

    private TreeNode root;

    public void Insert(ServiceRequest request)
    {
        root = InsertRecursive(root, request);
    }

    private TreeNode InsertRecursive(TreeNode node, ServiceRequest request)
    {
        if (node == null)
        {
            node = new TreeNode(request);
            return node;
        }

        if (request.RequestId < node.Request.RequestId)
            node.Left = InsertRecursive(node.Left, request);
        else if (request.RequestId > node.Request.RequestId)
            node.Right = InsertRecursive(node.Right, request);

        return node;
    }

    public ServiceRequest Search(int requestId)
    {
        return SearchRecursive(root, requestId);
    }

    private ServiceRequest SearchRecursive(TreeNode node, int requestId)
    {
        if (node == null || node.Request.RequestId == requestId)
            return node?.Request;

        if (requestId < node.Request.RequestId)
            return SearchRecursive(node.Left, requestId);
        else
            return SearchRecursive(node.Right, requestId);
    }
}
