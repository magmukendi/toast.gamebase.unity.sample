﻿using UnityEngine;
using UnityEngine.UI;

namespace GamebaseSample
{
    public class DownloadPanel : MonoBehaviour
    {
        [SerializeField]
        private Text messageText = null;
        [SerializeField]
        private Text totalDownloadStatusText = null;
        [SerializeField]
        private Progressbar totalDownloadProgress = null;
        [SerializeField]
        private GameObject progressObject = null;
        [SerializeField]
        private GameObject filesObject = null;

        [SerializeField]
        private DownloadResourceView downloadResourceView = null;

        private bool expanded = true;

        private void Awake()
        {
            ExpandBackground(false);
            progressObject.SetActive(false);
        }

        private void Update()
        {
            var progress = ResourceDownloader.Instance.Progress;
            if (progress == null)
            {
                return;
            }

            totalDownloadProgress.Percentage = progress.Percentage;

            if (progress.TotalFileBytes == 0)
            {
                progressObject.SetActive(false);
                messageText.text = LocalizationManager.Instance.GetLocalizedValue(GameStrings.RESOURCE_DOWNLOAD_WAIT);
            }
            else
            {
                progressObject.SetActive(true);
                messageText.text = string.Empty;

                uint completedCount = progress.CompletedFileCount;
                uint totalCount = progress.TotalFileCount;

                totalDownloadStatusText.text = string.Format("{0}/{1} ({2}/{3})",
                    StringUtil.BytesToString(progress.DownloadedBytes), StringUtil.BytesToString(progress.TotalFileBytes),
                    completedCount, totalCount);

                if (progress.FileMap != null)
                {
                    var threadCount = progress.FileMap.Count;

                    if (threadCount > 0)
                    {
                        ExpandBackground(true);
                    }

                    downloadResourceView.ThreadCount = threadCount;
                    for (int i = 0; i < threadCount; i++)
                    {
                        var file = progress.FileMap[i];
                        downloadResourceView[i].FileName = file.FileName;
                        downloadResourceView[i].ProgressStatus(Mathf.Min(100f, (file.DownloadedBytes / (float)file.TotalBytes) * 100.0f));
                    }
                }
            }
        }

        private void ExpandBackground(bool isExpand)
        {
            if (isExpand == expanded)
            {
                return;
            }

            expanded = isExpand;
            filesObject.SetActive(isExpand);
        }
    }
}